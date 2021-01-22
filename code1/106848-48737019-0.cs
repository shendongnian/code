    public static object GatDataInt(string Query, string Column)
        {
            SqlConnection DBConn = new SqlConnection(ConnectionString);
            if (DBConn.State == ConnectionState.Closed)
                DBConn.Open();
            SqlCommand CMD = new SqlCommand(Query, DBConn);
            SqlDataReader RDR = CMD.ExecuteReader();
            if (RDR.Read())
            {
                var Result = RDR[Column];
                RDR.Close();
                DBConn.Close();
                return Result;
            }
            return 0;
        }
