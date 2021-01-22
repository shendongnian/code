                public System.Data.DataTable GetDataTable(string strFileName)
            {
                System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0; Data Source = " + System.IO.Path.GetDirectoryName(strFileName) + "; Extended Properties = \"Text;HDR=YES;FMT=Delimited\"");
                conn.Open();
                string strQuery = "SELECT * FROM [" + System.IO.Path.GetFileName(strFileName) + "]";
                System.Data.OleDb.OleDbDataAdapter adapter = new System.Data.OleDb.OleDbDataAdapter(strQuery, conn);
                System.Data.DataSet ds = new System.Data.DataSet("CSV File");
                adapter.Fill(ds);
                return ds.Tables[0];
            }
