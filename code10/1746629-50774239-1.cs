      using (SqlCommand command = new SqlCommand("Select name from tempdb.sys.COLUMNS  Where object_id=OBJECT_ID('tempdb.dbo.#ApiWork')EXCEPT Select COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS where table_name = 'ApiWork'"))
                {
                    command.Connection = connection;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            pipe.Send("Something is different!");
                        }else{
                            pipe.Send("we're all good!");
                        }
                                          
                    }
                }
