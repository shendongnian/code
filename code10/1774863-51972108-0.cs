     string GameID = Request.QueryString["gameID"];
     SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["TrinoviContext"].ConnectionString);
      con.Open();
      SqlCommand cmd = new SqlCommand("usp_GetMatchupDetails", con);
      cmd.CommandType = CommandType.StoredProcedure;
      cmd.Parameters.AddWithValue("@GameID", GameID);
      SqlDataReader reader = cmd.ExecuteReader();
      while (reader.Read())
          {
              // populate properties I need for display on page
          }
      con.Close();
