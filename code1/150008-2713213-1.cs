    public abstract class MySingletonBase<T>
        where T : class
    {
        protected MySingletonBase()
        {
        }
        // All other functions that will be inherited.
    }
    public class MySingleton<T> : MySingletonBase<T>
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
