    /// <summary>
            /// 
            /// </summary>
            /// <param name="dic">key = param name, val = param value</param>
            /// <returns></returns>
            public static string AppendDataCT(Dictionary<string, string> dic) 
        { 
            if (dic.Count !=3 )
                throw new ArgumentOutOfRangeException("dic can only have 3 parameters");
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
                foreach (string s in dic.Keys)
                {
                    p1 = cmd.Parameters.AddWithValue(s, dic[s]);
                    p1.SqlDbType = SqlDbType.VarChar;
                }
    
                conn2.Open();
                cmd.ExecuteNonQuery();
                conn2.Close();
    
            }
