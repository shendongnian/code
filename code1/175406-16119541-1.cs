    using (SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TestConnectionString"].ToString()))
    using (SqlCommand cmd = new SqlCommand("Proc_TestProc", conn))
    {
     cmd.CommandType = CommandType.StoredProcedure;
     cmd.Parameters.AddWithValue("@Id", 1);
     var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
     returnParameter.Direction = ParameterDirection.ReturnValue;
     conn.Open();
     cmd.ExecuteNonQuery();
     var result = returnParameter.Value;
    }
