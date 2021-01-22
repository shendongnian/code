        using (SqlConnection conn2 = new SqlConnection(connString))
        {
            using (SqlCommand cmd = conn2.CreateCommand())
            {
                conn2.Open();               
                
                foreach(DataRow dr in dt.Rows)
                {
                     SqlParameter col1 = cmd.Parameters.AddWithValue(dic[0], dr[0].ToString());
                     SqlParameter col2 = cmd.Parameters.AddWithValue(dic[1], dr[1].ToString());
                     SqlParameter col3 = cmd.Parameters.AddWithValue(dic[2], Convert.ToDateTime(dr[2]));
                     cmd.ExecuteNonQuery();
                }
                conn2.Close();
            }
       }
