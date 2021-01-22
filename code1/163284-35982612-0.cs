    string strCheck = "SHOW TABLES LIKE \'tableName\'";
                    cmd = new MySqlCommand(strCheck, connection);
                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }
                    cmd.Prepare();
                    var reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {                             
                      Console.WriteLine("Table Exist!");
                    }
                    else (reader.HasRows)
                    {                             
                      Console.WriteLine("Table Exist!");
                    }
