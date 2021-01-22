    public class FileLog
    {
        public FileLog(Operation operation)
        {
            operation.EventLogHandler += print;
        }
    
        public void print(string str)
        {
            Console.WriteLine("write in File : " + str);
        }
    }
