    public class Singleton<T> where T : class, new()
    {
        static class SingletonCreator
        {
            internal static readonly T instance = new T();
        }
        public static T Instance
        {
            get
            {
                return SingletonCreator.instance;
            }
        }
    }
