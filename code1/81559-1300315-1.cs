    internal static void RunScriptFile(SqlConnection conn, string fileName)
    {
        long fileSize = 0;
        using (FileStream stream = File.OpenRead(fileName))
        {
            fileSize = stream.Length;
            using (StreamReader reader = new StreamReader(stream))
            {
                StringBuilder sb = new StringBuilder();
                string line = string.Empty;
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (string.Compare(line.Trim(), "GO", StringComparison.InvariantCultureIgnoreCase) == 0)
                    {
                        RunCommand(conn, sb.ToString());
                        sb.Length = 0;
                    }
                    else
                    {
                        sb.AppendLine(line);
                    }
                }
            }
        }
    }
    
    private static void RunCommand(SqlConnection connection, string commandString)
    {
        using (SqlCommand command = new SqlCommand(commandString, connection))
        {
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception while executing statement: {0}", commandString));
                Console.WriteLine(ex.ToString());
            }
        }
    }
