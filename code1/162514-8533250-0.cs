     public IList<string> ListTables()
        {
            List<string> tables = new List<string>();
            DataTable dt = _connection.GetSchema("Tables");
            foreach (DataRow row in dt.Rows)
            {
                string tablename = (string)row[2];
                tables.Add(tablename);
            }
            return tables;
        }
