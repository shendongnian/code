    public class Singleton
    {
        public static readonly Singleton instance;
        static Singleton()
        {
            instance = new Singleton();
        }
        private Singleton()
        {
           //constructor...
        }
    }
