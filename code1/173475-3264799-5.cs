    public class SomeDataSelector
    {
      public IEnumerable<SomeDataType> GetSomeData(int page, int size)
      {
        List<SomeDataType> result = new List<SomeDataType>();
        using (SqlConnection conn = new SqlConnection(...)) {
          using (SqlCommand command = new SqlCommand("GetSomeData", conn)) {
            command.CommandType = CommandType.StoredProcedure;
            
            using (SqlDataReader reader = command.ExecuteReader()) {
              while (reader.Read()) {
                // Do work here to create instance of SomeDataType.
                
                
              }
            }
          }
        }
        
        return result;
      }
    
      public int GetCoutOfSomeData()
      {
        using (SqlConnection conn = new SqlConnection(...)) {
          using (SqlCommand command = new SqlCommand("GetSomeData", conn)) {
            command.CommandType = CommandType.StoredProcedure;
            
            int result = (int)command.ExecuteScalar();
          }
        }
      }
    }
