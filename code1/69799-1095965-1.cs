    public sealed class Log
    {
        static Log instance=null;
        static readonly object lockObject = new object();
        static string path = "log.txt";
        
        Log()
        {
        }
    
        public static Log Instance
        {
          get
          {
                lock (lockObject)
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
           lock(lockObject)
           {
              using(StreamWriter sw = new StreamWriter(File.Open(path, FileMode.Append)))
              {
                 sw.WriteLine(message);
              }
           }
        }
    }
