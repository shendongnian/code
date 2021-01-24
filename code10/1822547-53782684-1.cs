    SqlConnection cnx = new SqlConnection(WebConfigurationManager.ConnectionStrings["yourConnName"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = cnx;
    cmd.CommandType = System.Data.CommandType.StoredProcedure;
    cmd.CommandText = "testSProc";
    cmd.Parameters.AddWithValue("name", "test Name");
    SqlParameter outputParam = cmd.Parameters.Add("outID", SqlDbType.Int);
    outputParam.Direction = ParameterDirection.Output;
    
    object oString;
    
    cnx.Open();
    cmd.ExecuteNonQuery();
    cnx.Close();
    
    TextBox1.Text = outputParam.Value.ToString();
