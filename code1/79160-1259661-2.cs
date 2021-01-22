    private static void ReadOrderData(string connectionString)
    {
          string commandText = "SELECT OrderID, CustomerID FROM dbo.Orders;";
          using (SqlConnection connection = new SqlConnection(connectionString))
          {
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                      connection.Open();
                      using (SqlDataReader reader = command.ExecuteReader())
                      {
                            while (reader.Read())
                            {
                                  Console.WriteLine(String.Format("{0}, {1}", 
                                    reader[0], reader[1]));
                            }
                      }
                }
          }
    }
