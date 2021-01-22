    using System.Data;
    using System.Data.
    using (IDbConnection conn = new OleDbConnection(...)) // <- add connection string
    {
        conn.Open();
        try
        {
            IDbCommand command = conn.CreateCommand();
            // option 1:
            command.CommandText = "SELECT ... FROM MyQuery";
            // option 2:
            command.CommandType = CommandType.TableDirect;
            command.CommandText = "MyQuery";
            // option 3:
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "MyQuery";
            using (IDataReader reader = command.ExecuteReader())
            {
                // do something with the result set returned by reader...
            }
        }
        finally
        {
            conn.Close();
        }
    }
