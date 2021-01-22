    private static void RunScript(SqlConnection connection, string script)
    {
        Regex regex = new Regex(@"\r{0,1}\nGO\r{0,1}\n");
        string[] commands = regex.Split(script);
    
        for (int i = 0; i < commands.Length; i++)
        {
            if (commands[i] != string.Empty)
            {
                using(SqlCommand command = new SqlCommand(commands[i], connection))
                {
                    command.ExecuteNonQuery();
                    command.Dispose();
                }
            }
        }
    }
