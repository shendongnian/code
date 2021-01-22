    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();
            Caller caller = new Caller();
            caller.FirstMethod(logger);
            caller.SecondMethod(logger);
        }
    }
    public class Caller
    {
        public void FirstMethod(Logger logger)
        {
            Console.Out.WriteLine("first");
            logger.Log();
        }
        public void SecondMethod(Logger logger)
        {
            Console.Out.WriteLine("second");
            logger.Log();
        }
    }
    public class Logger
    {
        public void Log()
        {
            StackTrace trace = new StackTrace();
            var frames = trace.GetFrames();
            Console.Out.WriteLine(frames[1].GetMethod().Name);
        }
    }
