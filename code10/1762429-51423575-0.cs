    private SqlDataReader Query(string query)
    {
            SqlCommand command = null;
            SqlDataReader result_reader = null;
            try
            {
                //conn.Open();
                command = new SqlCommand(query_to_perform, database_connection); //database_connection is the same as the as your "con" variable
                result_reader = command.ExecuteReader();
                this.successful_query = true;
                this.error_message = "";
                //conn.Close();
            }
            catch (SqlException ex)
            {
                this.successful_query = false;
                this.error_message = ex.Message;
                //destroy the connection on a failure
                database_connection = new SqlConnection();
                throw;
            }
    }
