            public static DataTable TableFromOleDB(string Connectstring, string Sql)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(Connectstring);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(Sql, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
            catch (OleDbException)
            {
                return null;
            }
        }
        public static DataTable TableFromMDB(string MDBfile, string Sql)
        {
            return TableFromOleDB(string.Format(sConnectionString, MDBfile), Sql);
        }
 
