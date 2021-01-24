    // IF this is your base class
    public class Log
    {
        public static bool Info(string Message)
        {
            Console.WriteLine(Message + " From Log");
            return true;
        }
        public static bool Success(string Message)
        {
            
            return true;
        }
        public static bool Error(string Message)
        {
            return true;
        }
    }
    //Then this can be your derived class
    public class LogFile : Log
    {
        public static new bool Info(string Message)
        {
            Console.WriteLine(Message + " From LogFile");
            return true;
        }
        public static new bool Success(string Message)
        {
            return true;
        }
        public static new bool Error(string Message)
        {
            return true;
        }
    }
