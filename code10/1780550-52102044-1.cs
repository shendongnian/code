    public DataTable SaveuserwithDataTable(string procedure, string username, string password)
            {
                SqlConnection connection = new SqlConnection();
                SqlCommand command = new SqlCommand(procedure, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                connection.Open();
                adapter.Fill(dt);
                var count = dt.Rows.Count;
                connection.Close();
                return dt;
            }
