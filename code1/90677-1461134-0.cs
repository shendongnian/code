      public class Program
      {
        private static string connString = @"Data Source=(local);Initial Catalog=DBTest;Integrated Security=SSPI;";
        public static void Main(string[] args)
        {
          using (SqlConnection conn = new SqlConnection(connString))
          {
            conn.Open();
    
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM MilliSeconds"))
            {
              cmd.Connection = conn;
    
              SqlDataReader reader = cmd.ExecuteReader();
              while(reader.Read())
              {
                DateTime dt = (DateTime)reader["TimeCollected"];
                int milliSeconds = dt.Millisecond;
                Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss.fff"));
              }
            }
          }
    
          Console.ReadLine();
        }
      }
