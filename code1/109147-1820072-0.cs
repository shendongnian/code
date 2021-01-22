        static void Main()
        {
            Console.WriteLine("Started at {0:HH:mm:ss:fff}", DateTime.Now);
            using (System.Threading.Timer timer = 
           new System.Threading.Timer(new TimerCallback(Tick), null, 3000, 1000))
            {
                // Wait for 10 seconds
                Thread.Sleep(10000);
                // Then go slow for another 10 seconds
                timer.Change(0, 2000);
                // unnecessary: Thread.Sleep(10000);
                Console.ReadKey(true);
            }
        }
        static void Tick(object state)
        {
            Console.WriteLine("Ticked at {0:HH:mm:ss.fff}", DateTime.Now);
        }
