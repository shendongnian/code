    if (openFileDialog1.ShowDialog() == DialogResult.OK)
    {
        string extension = Path.GetExtension(openFileDialog1.FileName); // get file extension
        string name = "Sheet1"
    
        using (System.Data.OleDb.OleDbConnection con = new System.Data.OleDb.OleDbConnection())
        {
            switch (extension)
            {
                case ".xls": // Excel 97-2003 files
                   // Excel 97-2003 connection string
                   string xlsconstr = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + openFileDialog1.FileName + "'; Extended Properties=Excel 8.0; HDR=Yes; IMEX=1;";
                   con.ConnectionString = xlsconstr;
                   break;
    
                case ".xlsx": // Excel 2007 files
                case ".xlsm":
                   // Excel 2007+ connection string, see in https://www.connectionstrings.com/ace-oledb-12-0/    
                   string xlsxconstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + openFileDialog1.FileName + "'; Extended Properties=Excel 12.0; HDR=Yes; IMEX=1;";
                   con.ConnectionString = xlsxconstr;
                   break;
            }
    
            using (System.Data.OleDb.OleDbCommand oconn = new System.Data.OleDb.OleDbCommand("SELECT * FROM [" + name + "$]", con))
            {
                con.Open();
    
                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(oconn);
                DataTable data = new DataTable();
                adapter.Fill(data);
                dataGridView1.DataSource = data;
            }
        }
    }
    else
    {
        MessageBox.Show("Operation Cancelled");
    }
