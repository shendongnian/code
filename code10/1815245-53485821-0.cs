    class Program
        {
            private static int numSpaces = 0;
    
            static void Main(string[] args)
            {
                Thread th = new Thread(CheckSpace);
    
                th.Start();
                th.Join();
    
                Console.WriteLine($"You pressed space {numSpaces} times");
                Console.Read();
            }
    
            private static void CheckSpace()
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                 
                while (true)
                {
                    if (Console.KeyAvailable)
                    {
                        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                        {
                            numSpaces++;
                        }
                    }
                    if (sw.ElapsedMilliseconds>= 4000)
                    {
                       
                        break;
                    }
    
                    Thread.Sleep(10);
                }
            }
        }
