            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter();
                //use SP name for command text
                SqlCommand command = new SqlCommand("usp_ProcedureName", connection);
                //stored procedure command type
                command.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = command;
                connection.Open();
                da.Fill(dataTable);
            }
