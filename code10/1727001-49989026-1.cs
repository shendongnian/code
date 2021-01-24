    class Program
    {
        static void Main(string[] args)
        {
            Log("message 1");
            Log("message 2");
            Log("message 3");
            Log("message 4");
        }
        public static void Log(string message)
        {
            var random = new Random();
            var i = random.Next(1, 11);
            Logger logger = null;
            if (i % 2 == 0)
            {
                logger = LogManager.GetLogger("Evens");
            }
            else
            {
                logger = LogManager.GetLogger("Odds");
            }
            logger.Trace($"{message} - {i}");
        }
    }
