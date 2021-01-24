    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Data.SqlClient;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                ofd.FileName = "";
                ofd.ShowDialog();
                string line = null;
                int i = 0;
                string strConnection =
                @"Data Source =.\SQLEXPRESS; AttachDbFilename = C:\USERS\JEF\DOCUMENTS\DATABASE1.MDF; Integrated Security = True; Connect Timeout = 30; User Instance = True";
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();
                    foreach (string file in ofd.FileNames)
                    {
                        using (StreamReader sr = File.OpenText(file))
                        {
                            DataTable dt = new DataTable();
                            string symbolName = dt.Rows[1][0].ToString();
                            string createTablerow = string.Format("create table [{0}] (code1 VARCHAR(100) COLLATE Arabic_CI_AI_KS_WS,date1 varchar(50),open1 varchar(50),high1 varchar(50),low1 varchar(50),close1 varchar(50),vol1 varchar(50))",
                               symbolName);
                            using (SqlCommand command1 = new SqlCommand(createTablerow, connection))
                            {
                                command1.ExecuteNonQuery();
                                using (SqlBulkCopy copy = new SqlBulkCopy(connection))
                                {
                                    copy.ColumnMappings.Add(0, "code1");
                                    copy.ColumnMappings.Add(1, "date1");
                                    copy.ColumnMappings.Add(2, "open1");
                                    copy.ColumnMappings.Add(3, "high1");
                                    copy.ColumnMappings.Add(4, "low1");
                                    copy.ColumnMappings.Add(5, "close1");
                                    copy.ColumnMappings.Add(6, "vol1");
                                    copy.DestinationTableName = "[" + symbolName + "]";
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        string[] data = line.Split(',');
                                        if (data.Length > 0)
                                        {
                                            if (i == 0)
                                            {
                                                foreach (var item in data)
                                                {
                                                    dt.Columns.Add(new DataColumn());
                                                }
                                                i++;
                                            }
                                            DataRow row = dt.NewRow();
                                            row.ItemArray = data;
                                            dt.Rows.Add(row);
                                        }
                                        copy.WriteToServer(dt);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
