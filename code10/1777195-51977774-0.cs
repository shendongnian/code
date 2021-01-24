            using (MySqlConnection connection = new MySqlConnection(con))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "SELECT material FROM tbl1 WHERE vendor=@vendor"
                       command.Parameters.AddWithValue("@vendor", UserInputVar);
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
