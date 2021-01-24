    class Program
        {
            static void Main(string[] args)
            {
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        // Do something
                    }
                } while (Console.ReadKey(true).Key == ConsoleKey.S);
                {
                    MessageBox.Show("Test");
                }
            }
        }
