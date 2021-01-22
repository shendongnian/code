    using System.Data.OleDb;
    ...
    using (OleDbConnection conn = new OleDbConnection())
    {
        conn.ConnectionString = "Provider=sqloledb;Data Source=yourServername\\yourInstance;Initial Catalog=databaseName;Integrated Security=SSPI;";
        using (OleDbCommand cmd = new OleDbCommand())
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from yourTable";
            using (OleDbDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Console.WriteLine(dr["columnName"]);
                }
            }
        }
    }
