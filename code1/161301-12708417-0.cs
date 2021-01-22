            try
            {
                string connectionString = String.Format("server=192.168.1.12;port=3306;database=taskmanagement;UID=root;password=");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("connect");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
