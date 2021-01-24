        connection = new SqlConnection
                {
                    ConnectionString = ConfigurationManager.ConnectionStrings[DatabaseConnectionName].ConnectionString
                };
                connection.Open();
                //storedProcedureName is from your database
                command = new SqlCommand(@"[dbo].[storedProcedureName]", connection)                
                {
                    CommandType = CommandType.StoredProcedure
                };
                //passing a parameter to the stored procedure
                command.Parameters.AddWithValue("@StudyID", khStudyId);
                reader = command.ExecuteReader();
