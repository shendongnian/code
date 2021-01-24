    public class Runner
    {
        public static string Bob1()
        {
            return "Hi";
        }
        public static string Bob2()
        {
            return "Hi";
        }
        public Runner(string hello)
        {
            // Some logic here
        }
        public Runner() : this(Bob2()) { }
