        string extension = Path.GetExtension(openFileDialog1.FileName);
        using (System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection())
        {
            switch (extension)
            {
                case ".xls":
                    string xlsconStr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + openFileDialog1.FileName + "'; Extended Properties=Excel 8.0;";
                    con.ConnectionString = xlsconStr;
                    break;
                case ".xlsx":
                case ".xlsm":
                    string xlsxconStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + openFileDialog1.FileName + "'; Extended Properties=Excel 12.0;";
                    con.ConnectionString = xlsxconStr;
                    break;
            }
                using (System.Data.OleDb.OleDbCommand oconn = new System.Data.OleDb.OleDbCommand("SELECT * FROM [" + listBox1.SelectedIndex.ToString() + "$]", con))
                {
                    con.Open();
                    System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(oconn);
                    System.Data.DataTable data = new System.Data.DataTable();
                    adapter.Fill(data);
                    dataGridView1.DataSource = data;
                }
        }
