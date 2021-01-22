    public abstract class Singleton<T> 
    {
        protected static Lazy<T> instance;
        public static T Instance => instance.Value;
    }
    public sealed class Adapter : Singleton<Adapter>
    {
        static Adapter()
        {
            instance = new Lazy<Adapter>(() => new Adapter());
        }
        private Adapter() { }
    }
   
