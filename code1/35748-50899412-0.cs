    public class ConsoleLog
    {
        public ConsoleLog(Operation operation)
        {
            operation.EventLogHandler += print;
        }
    
        public void print(string str)
        {
            Console.WriteLine("write on console : " + str);
        }
    }
    
