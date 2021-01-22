    public abstract class Singleton
    {
        private static readonly object locker = new object();
        private static HashSet<object> registeredTypes = new HashSet<object>();
        protected Singleton()
        {
            lock (locker)
            {
                if (registeredTypes.Contains(this.GetType()))
                {
                    throw new InvalidOperationException(
                        "Only one instance can ever  be registered.");
                }
                registeredTypes.Add(this.GetType());
            }
        }
    }
    
    public class Repository : Singleton
    {
        public static readonly Repository Instance = new Repository();
    
        private Repository()
        {
        }
    }
