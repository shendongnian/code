    public class Context
    {
        public static Context Current { get; set; }
        public IPlanDocument Document { get; set; }
        static Context()
        {
            Current = new Context();
        }
    }
