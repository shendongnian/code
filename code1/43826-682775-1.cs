                SqlCeConnection connection = new SqlCeConnection(connectionString);
                SqlCeCommand identChangeCommand = connection.CreateCommand();
                identChange.CommandText = "SET IDENTITY_INSERT SomeTable ON";
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO testTable (Id, column1, column2..) VALUES (10,val1,val2...)";
                try
                {
                    connection.Open();
                    identChange.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                }
    
                catch (SqlCeException ex)
                {
                    //log ex
                }
                finally
                {
                    connection.Close();
                }
