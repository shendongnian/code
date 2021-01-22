    private static void Main(string[] args)
            {
                Thread thrd1 = new Thread(new ThreadStart(Trmain));
    
                thrd1.Start();
            }
    
            private static void Trmain()
            {
                for (; ; )
                {
                    Console.WriteLine("waiting 10 minutes...");
                    Thread.Sleep(1000 * 60 * 10);
                }
            } 
