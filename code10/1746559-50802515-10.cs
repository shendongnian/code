    using log4net;
    using System.IO;
    
    namespace LogIssue
    {
        internal class Worker
        {
            static ILog _log = LogManager.GetLogger(typeof(Worker));
    
            public void DoWork() {
                _log.Info("Why is this line not logged?");
                File.WriteAllText("D:\\file.txt", "Hello, World!");
            }
        }
    }
