    onnection = new SqlConnection(ConfigurationManager.ConnectionStrings[DatabaseConnectionName].ConnectionString);
                connection.Open();
                command = new SqlCommand(@"[dbo].[UserInformation]", connection)
                {
                    CommandType = CommandType.Text
                };
                command.Parameters.AddWithValue("@StudyName", sponsorName);
                command.CommandText = @"select ID from [dbo].[Sponsors] where [Name] = @StudyName";
                reader = command.ExecuteReader();
                if (reader != null)
                {
                    if (reader.Read())
                    {
                        output = Convert.ToInt32(reader["ID"]);
                    }
                }
