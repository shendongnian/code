        static void Main(string[] args)
        {
            try
            {
                DoStuff();
            }
            catch (IOException ex)
            {
                try
                {
                    Console.WriteLine("IOException" + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Another exception!" + ex.Message);
                }
            }
        }
