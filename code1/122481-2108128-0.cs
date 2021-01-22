    using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString))
    {
      cn.Open();
      cn.StatisticsEnabled = true;
      using (SqlCommand cmd = new SqlCommand("SP", cn))
      {
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader dr = cmd.ExecuteReader())
        {
          while (dr.Read())
          {
    
          }
        }
      }
    
      IDictionary stats = cn.RetrieveStatistics();
      long selectRows = (long)stats["SelectRows"];
      long executionTime = (long)stats["ExecutionTime"];
    }
