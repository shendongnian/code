        public DataTable ReadExcel(string fileName, string TableName)
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0\"");
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + TableName, conn);
            
            try
            {
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (!reader.IsClosed)
                {
                    dt.Load(reader);
                }
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
