    public bool Blah()
    {
       using (SqlConnection conn = new SqlConnection())
       {
         SqlCommand cmd = new SqlCommand("sproc", conn);
         cmd.CommandType = CommandType.StoredProcedure;
    
         // add parameters
         cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, int.MaxValue, ParameterDirection.Output));
           
         conn.Open();
    
          // *** GRAB output paramter here, how?????????
         cmd.ExecuteNonQuery();
         int id = cmd.Parameters["@ID"].Value;
    
         conn.Close();
       }
    }
