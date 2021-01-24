    string connectionString = "Server=SomeServer;Database=i got you this is notthe real database;User ID=same;Password=same for password;";
    using (MySqlConnection connection = new MySqlConnection(connectionString))
    {
        using (MySqlCommand command = new MySqlCommand())
        {
            string sql = "SELECT * FROM yourTable WHERE hwid = @val1";
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.Parameters.AddWithValue("@val1", "GetHDDSerial");
            connection.Open();
            using (MySqlDataAdapter adapter = new MySqlDataAdapter())
            {
                using (DataSet ds = new DataSet())
                {
                    adapter.SelectCommand = command;
                    adapter.Fill(ds);
                    if (ds.Tables.Count > 0)
                    {
                        DataTable dt = ds.Tables[0];
                        foreach (DataRow row in dt.Rows)
                        {
                            // Do something here. You can access the data like this:
                            // row["Id"] or whatever your field names are.
                            // int id = (int) row["Id"];
                            // Of course, I don't know your field names, so you'll have to complete this.
                        }
                    }
                }
            }
        }
    }
