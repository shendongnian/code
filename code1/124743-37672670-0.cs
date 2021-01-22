    public class Singleton
    {
        private static Singleton singletonInstance = CreateSingleton();
        private Singleton()
        {
        }
        private static Singleton CreateSingleton()
        {
            if (singletonInstance == null)
            {
                singletonInstance = new Singleton();
            }
            return singletonInstance;
        }
        public static Singleton Instance
        {
            get { return singletonInstance; }            
        }
    }
