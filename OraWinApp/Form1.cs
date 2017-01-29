using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//using Oracle.DataAccess.Client;
//using Oracle.DataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace OraWinApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oradb = "Data Source=  (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE))); User Id=HR;Password=HR;";
            OracleConnection conn = new OracleConnection(oradb);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            //cmd.CommandText = "select department_name from departments where department_id = 30";
            cmd.CommandText = textBox1.Text;
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            //dr.Read();
            //label1.Text = dr.GetString(0);
            richTextBox1.Text = "";

            //richTextBox1.AppendText("Columnas: " + dr.FieldCount + "\n");
            String names = "";
            for (int i = 0; i < dr.FieldCount; i++)
            {
                names += "[" + dr.GetName(i) + "]\t";
            }
            richTextBox1.AppendText(names + "\n");

            while (dr.Read())
            {
                String fila = "";
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    String Valor = dr.GetValue(i).ToString();
                    int longitud = dr.GetName(i).ToString().Length;
                    fila += String.Format(" {0,-"+longitud+"}", Valor) + " \t";
                }
                richTextBox1.AppendText(fila + "\n");
            }
            conn.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string oradb = "Data Source=  (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE))); User Id=HR;Password=HR;";
            OracleConnection conn = new OracleConnection(oradb);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "execute registrar_estudiante('xd','xd','xd',SYSDATE);";
            //cmd.CommandText = textBox1.Text;
            cmd.CommandType = CommandType.Text;
        }
    }
}

