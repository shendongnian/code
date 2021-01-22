    public List<Model> GetModels()
    {
      List<Model> result = new List<Model>();
    
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
      return result;
    }
