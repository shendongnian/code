            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand command = new SqlCommand(cmd, connection);
                da.SelectCommand = command;
                connection.Open();
                da.Fill(dataTable);
            }
