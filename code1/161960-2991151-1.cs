    public static string AppendDataCT(DataRow dr, Dictionary<int, string> dic) 
        { 
            string connString = ConfigurationManager.ConnectionStrings["AW3_string"].ConnectionString; 
            string errorMsg; 
     
            try
            {
                SqlConnection conn2 = new SqlConnection(connString);
                SqlCommand cmd = conn2.CreateCommand();
                cmd.CommandText = "dbo.AppendDataCT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn2;
                SqlParameter p1, p2, p3;
                    p1 = cmd.Parameters.AddWithValue((string) dic[0], (string) dr[0]);
                    p1.SqlDbType = SqlDbType.VarChar;
                    p2 = cmd.Parameters.AddWithValue((string) dic[1], (string) dr[1]);
                    p2.SqlDbType = SqlDbType.VarChar;
                    p3 = cmd.Parameters.AddWithValue((string) dic[2], (string) dr[2]);
                    p3.SqlDbType = SqlDbType.VarChar;
                    conn2.Open();
                    cmd.ExecuteNonQuery();
                    conn2.Close();
               
            }
