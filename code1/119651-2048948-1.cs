        static void Main()
        {
            try 
            {
                Environment.FailFast("failed");
            }
            finally
            {
                Console.WriteLine("finally!");
            }
        }
