    public IEnumerable<SampleModel> RetrieveSampleByFilter(string query, params SqlParameter[] parameters)
    {
         using(var connection = new SqlConnection(dbConnection))
              using(var command = new SqlCommand(query, connection))
              {
                  connection.Open();
                  if(parameters.Length > 0)
                      foreach(var parameter in parameters)
                           command.Parameters.Add(parameter);
    
                           // Could also do, instead of loop:
                           // command.Parameters.AddRange(parameters);
                  using(var reader = command.ExecuteReader())
                       while(reader != null)
                            yield return new Sample()
                            {
                                 Id = reader["Id"],
                                 ...
                            }                   
              }
    }
