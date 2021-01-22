    public static void Run()
            {
                try
                {
                    _command.Parameters.AddWithValue("@Param1", 300101);
                    _command.Parameters.AddWithValue("@Param2", 100);
                    _command.Parameters.AddWithValue("@Param3", 200);
                   
                    _command.ExecuteScalar();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
