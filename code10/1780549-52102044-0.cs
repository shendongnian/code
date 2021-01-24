    public DataSet saveuser(string procedure, string username, string password)
            {
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand(procedure, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataset = new DataSet();
                connection.Open();
                adapter.Fill(dataset);
                var count = dataset.Tables?[0].Rows.Count;
                connection.Close();
                return dataset;
            }
