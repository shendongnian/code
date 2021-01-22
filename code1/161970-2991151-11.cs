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
             // you probably want to do a string.IsNullOrEmpty(connString) and throw a ConfigurationException here is true to quickly identify this annoying bug ...
                 
 
               using(SqlConnection conn2 = new SqlConnection(connString))
               {
                using( SqlCommand cmd = conn2.CreateCommand())
                {
                cmd.CommandText = "dbo.AppendDataCT";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn2;
                
                foreach (string s in dic.Keys)
                {                    
                    SqlParameter  p = cmd.Parameters.AddWithValue(s, dic[s]);
                    p.SqlDbType = SqlDbType.VarChar;
                }
    
                conn2.Open();
                cmd.ExecuteNonQuery();
                conn2.Close();
               }
               }
            }
