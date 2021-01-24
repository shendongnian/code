    try
    {
      SqlConnection con1 = new SqlConnection(connectionString);
      SqlCommand cmd1 = new SqlCommand(cmdString, con1);
      con1.Open();
      var rowsAffected = cmd1.ExecuteNonQuery();
      con1.Close();
      //Some Code
      if(rowsAffected > 0)
      {
        SqlConnection con2 = new SqlConnection(connectionString);
        SqlCommand cmd2 = new SqlCommand(cmdString2, con2);
        con2.Open()
        cmd2.ExecuteNonQuery();
        con2.Close();
      }
    }
    catch(Exception ex)
    {
      //handle error in insert
    } 
