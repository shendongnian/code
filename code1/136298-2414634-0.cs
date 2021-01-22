    class Program
    {
        static void Main(string[] args)
        {
            if (IsRunning())
            {
                return;
            }
            else
            {
                for (int x = 0; x < 10; x++)
                {
                    //Do Stuff
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
        private static bool IsRunning()
        {
            
            Process[] P = Process.GetProcessesByName( Process.GetCurrentProcess().ProcessName  ) ;
            return P.Count() > 1;
        }
    }
