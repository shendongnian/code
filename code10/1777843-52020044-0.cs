     using (AdomdConnection connection = new AdomdConnection("Data source=localhost;initial catalog=MultidimensionalProject2;"))
            {
                connection.Open();
                using (AdomdCommand command = new AdomdCommand("SELECT PredictAssociation([Association].[v Machine Purchase Stat], 5) From  [Association]", connection))
                {
                    using (AdomdDataReader reader = command.ExecuteReader())
                    {                        
                        List<object> asd = new List<object>();
                        while (reader.Read())
                        {
                            var r2 = reader.GetData(0);
                            while (r2.Read())
                            {
                                Console.WriteLine(r2[1]);
                            }
                        }
                        reader.Close();
                    }
                }
                connection.Close();
            }
            Console.ReadKey();
