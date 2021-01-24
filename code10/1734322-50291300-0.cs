    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication16
    {
        public partial class Form1 : Form
        {
            DataTable dt = new DataTable();
            public Form1()
            {
                InitializeComponent();
                dt.Columns.Add("Begin Time", typeof(DateTime));
                dt.Columns.Add("HA Serial Number", typeof(string));
                dt.Columns.Add("Results", typeof(string));
                dt.Columns.Add("Serial Number", typeof(string));
                dt.Columns.Add("Test State", typeof(string));
                dt.Columns.Add("Lower Limits Amps", typeof(decimal));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("KiloVolts Output", typeof(decimal));
                dt.Columns.Add("Leakage milliAmps", typeof(decimal));
                for (int i = 0; i < 10; i++)
                {
                    DataRow newRow = dt.Rows.Add();
                    newRow["Begin Time"] = DateTime.Now;
                    newRow["HA Serial Number"] = i;
                    newRow["Results"] = (i % 2) == 0 ? "Passed" : "Failed";
                    newRow["Serial Number"] = "SN" + i.ToString();
                    newRow["Test State"] = "Running not walking";
                    newRow["Lower Limits Amps"] = -1.25;
                    newRow["Name"] = "Power Out";
                    newRow["KiloVolts Output"] = .001;
                    newRow["Leakage milliAmps"] = i/1000 + .001;
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
