        private static bool DoesTableExist(string TableName)
        {
            using (SqlConnection conn = 
                         new SqlConnection("Data Source=DBServer;Initial Catalog=InitialDB;User Id=uname;Password=pword;"))
            {
                conn.Open();
                DataTable dTable = conn.GetSchema("TABLES", 
                               new string[] { null, null, "MyTableName" });
                return (dTable.Rows.Count > 0);
            }
        }
