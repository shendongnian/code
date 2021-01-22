    public class Singleton<T>
        where T : class, new()
    {
        private Singleton() { }
        public static T Instance 
        { 
            get 
            { 
                return SingletonCreator.instance; 
            } 
        } 
        
        private class SingletonCreator 
        {
            static SingletonCreator() { }
            internal static readonly T instance = new T();
        }
    }
