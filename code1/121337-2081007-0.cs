    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }
    
        private StreamReader sr;
        private bool forcefullyClose = false;
    
        public Program()
        {
            
            new Thread(new ThreadStart(this.Close)).Start(); ;
    
            using (sr = new StreamReader(Console.OpenStandardInput()))
            {
                string line;
                while (!forcefullyClose && (line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }        
        }
    
        public void Close()
        {
            Thread.Sleep(5000);
            forcefullyClose = true;
            Console.WriteLine("Stream Closed");
        }
    }
