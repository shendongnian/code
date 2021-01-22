    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
    {
      cn.Open();
      cn.StatisticsEnabled = true;
      using (SqlCommand cmd = new SqlCommand("SP", cn))
      {
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
          using (SqlDataReader dr = cmd.ExecuteReader())
          {
            while (dr.Read())
            {
    
            }
          }
        }
        catch (SqlException ex)
        {
          // Inspect the "ex" exception thrown here
        }
      }
    
      IDictionary stats = cn.RetrieveStatistics();
      long selectRows = (long)stats["SelectRows"];
      long executionTime = (long)stats["ExecutionTime"];
    }
