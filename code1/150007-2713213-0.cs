    public class MySingleton<T>
        where T : class
    {
        private static MySingleton<T> instance;
        protected MySingleton()
        {
        }
        public static MySingleton<T> GetInstance()
        {
            if (instance == null)
            {
                instance = new MySingleton<T>();
            }
            return instance;
        }
    }
