    public List<Model> GetModels()
    {
      List<Model> result = new List<Model>();
    
      using(SqlConnection conn = new SqlConnection(ConfigurationManager.
                                         ConnectionStrings["SampleCs"].ConnectionString))
      {
         using(SqlCommand cmd = new SqlCommand("SP_GetModels", conn))
         {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@CategoryID", SqlDbType.BigInt, 10).Value = CategoryID;
            conn.Open();
     
            using(SqlDataReader dreader = cmd.ExecuteReader())
            { 
               while(dreader.Read())
               {
                   Model workItem = new Model() 
                                    { ModelID = dreader.GetInt(0), 
                                      ModelName = dreader.GetString(1) };
                   result.Add(workItem);
               }
               reader.Close();
            }
            conn.Close();
        }
      }
      return result;
    }
