      var connect = ConfigurationManager.ConnectionStrings["NorthWind"].ToString();
      var query = "Select * From Products Where ProductID = @ProductID";
      using (var conn = new SqlConnection(connect))
      {
        using (var cmd = new SqlCommand(query, conn))
        {
          cmd.Parameters.Add("@ProductID", SqlDbType.Int);
          cmd.Parameters["@ProductID"].Value = Convert.ToInt32(Request["ProductID"]);
          conn.Open();
    
          conn.Open();
          //Process results
        }
      }
