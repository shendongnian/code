    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        private static bool instantiated;
        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());
        public static T Instance => instance.Value;
        protected Singleton()
        {
            if (instantiated)
                throw new Exception();
            instantiated = true;
        }
    }
    public /* sealed */ class Adapter : Singleton<Adapter>
    {
    }
