        public void deleteRow()
        {
           string connectionString = "Data Source=server\\instance;Initial Catalog=db;Integrated Security=True;Application Name=ЦС"; ;
           string queryString = "DELETE FROM Test_Table WHERE ID = 5";
           using (SqlConnection connection = new SqlConnection(
           connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
