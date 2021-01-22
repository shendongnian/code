    public sealed class Log
    {
        static Log instance=null;
        static readonly object lock = new object();
        static string path = "log.txt";
        
        Log()
        {
        }
    
        public static Log Instance
        {
          get
          {
                lock (lock)
                {
                    if (instance==null)
                    {
                        instance = new Log();
                    }
                    return instance;
                }
           }
        }
    
        public void WriteLine(string message)
        {
           lock(lock)
           {
              using(StreamWriter sw = new StreamWriter(File.Open(path, FileMode.Append)))
              {
                 sw.WriteLine(message);
              }
           }
        }
    }
