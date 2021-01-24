    private void GetSheets()
            {
                string strFileName = @"C:\Users\xxx\Documents\Excel\TestImport.xlsx";
                string strCon = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={strFileName};Extended Properties=""Excel 12.0;HDR=YES;""";
                DataTable dt;
                using (OleDbConnection cn = new OleDbConnection(strCon))
                {
                    cn.Open();
                    dt = cn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                }
                string[] exSheets = new string[dt.Rows.Count];
                int i = 0;
                foreach (DataRow row in dt.Rows)
                { 
                    //Get the sheet name from the DataTable
                    string strSheetName = row["TABLE_NAME"].ToString();
                    exSheets[i] = strSheetName;
                    i ++;
                }
                cboSheets.Items.AddRange(exSheets);
            }
    
            private void btnFillGrid_Click(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                string strFileName = @"C:\Users\xxx\Documents\Excel\TestImport.xlsx";
                string  strCon  = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={strFileName};Extended Properties=""Excel 12.0;HDR=YES;""";
                using (OleDbConnection cn = new OleDbConnection(strCon))
                {
    
                    using (OleDbCommand cmd = new OleDbCommand($"Select * From [{cboSheets.Text}];", cn))
                    {
                        cn.Open();
                        using (OleDbDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                }
                dataGridView1.DataSource = dt;
            }
        }
    }
