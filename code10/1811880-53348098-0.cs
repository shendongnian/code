    using (SqlConnection sqlConnection = new SqlConnection(Connection.connectionString))
        {
            SqlCommand command = new SqlCommand("INSERT INTO IngredientTypes (Name) VALUES (@name)", connection);
            command.Parameters.Add("@name", SqlDbType.Varchar, 155);
            command.Parameters["@name"].Value = Name; //make sure Name is string.
    
            try
            {
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
