    class MainClass
    {
        public static void FireTimerAt(DateTime next)
        {
            TimeSpan waitTime = next - DateTime.Now;
            new Timer(delegate(object s) {
                            Console.WriteLine("{0} : {1}",
                            DateTime.Now.ToString("HH:mm:ss.ffff"), s);
                        }
                  , null, waitTime, new TimeSpan(-1));
        }
    }
