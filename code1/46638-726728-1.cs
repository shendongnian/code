    public class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static Singleton Instance
        {
            get { return instance; }
        }
        private Singleton()
        {
            // Do stuff
        }
    }
