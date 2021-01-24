    class Singleton
    {
        static readonly Singleton _instance;
        public static Singleton Instance { get { return _instance; } }
        private Singleton()
        {
            Console.WriteLine("Instance Constructor");
        }
        static Singleton()
        {
            _instance = new Singleton();
            Console.WriteLine("Static Constructor");
        }
    }
