    using (SqlConnection con = new SqlConnection(connetionString))
                {
                    using (var command = new SqlCommand(storedProcName, con))
                    {
                        foreach (var item in sqlParams)
                        {
                            item.Direction = ParameterDirection.Input;
                            item.DbType = DbType.String;
                            command.Parameters.Add(item);
                        }
                        command.CommandType = CommandType.StoredProcedure;
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
