        public void deleteRow()
        {
           string connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password = myPassword; ";
           string queryString = "DELETE FROM Test_Table WHERE ID = 5";
           using (SqlConnection connection = new SqlConnection(
           connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
