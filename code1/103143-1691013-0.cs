    class Prog
    {
        static void Main(string[] args)
        {
            Thread t;
            t = new Thread(new ThreadStart(ThreadStartServer));
            t.IsBackground = true;
            try
            {
                t.Start();
                // time consuming work here
            }
            catch (System.IO.IOException)
            {
                // from your example
            }
            
            t.Join();
        }
        static public void ThreadStartServer()
        {
            while (true)
            {
                int counter=0;
                while (++counter < 10)
                {
                    Console.WriteLine("working.");
                    // do time consuming things
                    Thread.Sleep(500);
                    
                }
                return;
           
            } 
        }
    }
