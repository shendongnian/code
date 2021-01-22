    public void createDatabase(string server, string port, string database, string username, string password)
        {
            string connectionstring = string.Format("Server = {0}; Port ={1}; Uid = {2}; Pwd = {3}; pooling = true; Allow Zero Datetime = False; Min Pool Size = 0; Max Pool Size = 200; ", server, port, username, password);
            using (var con = new MySqlConnection { ConnectionString = connectionstring })
            {
                using (var command = new MySqlCommand { Connection = con })
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    try
                    {
                        con.Open();
                    }
                    catch (MySqlException ex)
                    {
                        msgErr(ex.Message + " connection error.");
                        return;
                    }
                    try
                    {
                        command.CommandText = @"CREATE DATABASE IF NOT EXISTS @database";
                        command.Parameters.AddWithValue("@database", database);
                        command.ExecuteNonQuery();//Execute your command
                    }
                    catch (MySqlException ex)
                    {
                        msgErr(ex.Message + " sql query error.");
                        return;
                    }
                }
            }
        }
