    private bool chkDBExists(string connectionStr, string dbname)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionStr))
        {
            using (NpgsqlCommand command = new NpgsqlCommand
                ($"SELECT DATNAME FROM pg_catalog.pg_database WHERE DATNAME = '{dbname}'", conn))
            {
                try
                {
                    conn.Open();
                    var i = command.ExecuteScalar();
                    conn.Close();
                    if (i.ToString().Equals(dbname)) //always 'true' (if it exists) or 'null' (if it doesn't)
                        return true;
                    else return false;
                }
                catch (Exception e) { return false; }
            }
        }
    }
