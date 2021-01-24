    static void Main(string[] args)
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = "franktest.mysql.database.azure.com",
                Database = "frankdemo",
                UserID = "frank@franktest",
                Password = "gr3enRay14!",
                SslMode = MySqlSslMode.Required,
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                conn.Open();
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = "DROP TABLE IF EXISTS inventory;";
                    command.ExecuteNonQuery();
                    Console.WriteLine("Finished dropping table (if existed)");
                    command.CommandText = "CREATE TABLE inventory (id serial PRIMARY KEY, name VARCHAR(50), quantity INTEGER);";
                    command.ExecuteNonQuery();
                    Console.WriteLine("Finished creating table");
                    command.CommandText = @"INSERT INTO inventory (name, quantity) VALUES (@name1, @quantity1),
                        (@name2, @quantity2), (@name3, @quantity3);";
                    command.Parameters.AddWithValue("@name1", "banana");
                    command.Parameters.AddWithValue("@quantity1", 150);
                    command.Parameters.AddWithValue("@name2", "orange");
                    command.Parameters.AddWithValue("@quantity2", 154);
                    command.Parameters.AddWithValue("@name3", "apple");
                    command.Parameters.AddWithValue("@quantity3", 100);
                    int rowCount = command.ExecuteNonQuery();
                    Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
                }
                // connection will be closed by the 'using' block
                Console.WriteLine("Closing connection");
            }
            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }
