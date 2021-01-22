     public class Logger : ILogger
        {
            public void Log(string stringToLog)
            {
               Console.WriteLine(stringToLog);
            }
        }
    
        public interface ILogger
        {
            void Log(string stringToLog);
        }
