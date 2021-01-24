    try
                {
                    using (var dbConn = new DbConn())
                    {
                        await dbConn.Connection.OpenAsync();
    
                        command = "UPDATE user SET name = @name WHERE name IS NULL AND id = @id";
    
                        using (MySqlCommand update = dbConn.Connection.CreateCommand())
                        {
                            update.CommandText = command;
                            update.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                            update.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
                            await update.ExecuteNonQueryAsync();
                            return true;
                        }
                    }
                }
                catch (Exception er)
                {
                    return false;
                }
