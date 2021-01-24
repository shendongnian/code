    class App
    {
        public delegate void StopHandler();
        public event StopHandler OnStop;
        private object keepAliveLock = new object();
        private bool keepAlive = true;
    
    ....
        private void Update()
        {
            int counter = 0;
    
            while (true)
            {
                lock(keepAliveLock)
                {
                     if(!keepAlive) 
                          break;
                }
                counter++;
    
                Console.WriteLine(string.Format("[{0}] Update #{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), counter));
    
                Thread.Sleep(3000);
            }
        }
    }
