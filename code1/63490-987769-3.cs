    public void ExecuteQuery(string connectionString, string sql)
            {
                using (System.Data.SqlClient.SqlConnection theConnection = new System.Data.SqlClient.SqlConnection(connectionString))
                using (System.Data.SqlClient.SqlCommand theCommand = new System.Data.SqlClient.SqlCommand(sql, theConnection))
                {
                    theConnection.Open();
                    theCommand.CommandType = CommandType.Text;
                    theCommand.ExecuteNonQuery();
                }
            }
