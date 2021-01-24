        SqlConnection conn = new SqlConnection(connectionString);
        if (conn.State == ConnectionState.Closed)
        {
            conn.Open();
        }
        String sql = "Select top 100 * from xyz";
        SqlCommand cmd = new SqlCommand(sql, conn);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet Output = new DataSet();
        adapter.Fill(Output, "out");
        GridViewOutput.DataSource = Output.Tables["out"];
        GridViewOutputData.DataBind();
        /*  using (SqlCommand cmd = new SqlCommand(sql, conn))
          {
              using (SqlDataReader reader = cmd.ExecuteReader())
              {
                  while (reader.Read())
                  {
                      Response.Write( reader.GetString(0)+ reader.GetString(2));
                  }
              }
          }*/
      conn.Close();
