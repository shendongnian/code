            try {
                var connection = new SqlConnection(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Sandbox;Integrated Security=SSPI;");
                connection.Open();
                var command = new SqlCommand("throw 50000, 'oops', 1;", connection);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex) {
                Console.WriteLine(ex.ErrorCode + ": " + ex.Number + ": " + ex.Message);
                for (int i = 0; i < ex.Errors.Count; i++)
                    Console.WriteLine(ex.Errors[i].Number + ": " + ex.Errors[i].Message);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            };
        }
