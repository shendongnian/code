    public abstract class Singleton<T> where T : Singleton<T>
    {
        protected Singleton(SingletonKey key) { }
        private static SingletonKey _key;
        private static SingletonKey Key
        {
            get
            {
                if (_key == null) SingletonKey.Initialize();
                return _key;
            }
        }
        protected class SingletonKey
        {
            private SingletonKey()
            {
            }
            public static void Initialize()
            {
                if (_key == null)
                {
                    _key = new SingletonKey();
                }
            }
        }
        
        protected static Func<SingletonKey, T> Creator;
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null) instance = Creator(Key);
                return instance;
            }
        }
    }
    public class MySingleton : Singleton<MySingleton>
    {
        public string Name { get; set; }
        public static void Initialize()
        {
            Creator = (key) => new MySingleton(key);
        }
        protected MySingleton(SingletonKey key) : base(key)
        {
        }
    }
