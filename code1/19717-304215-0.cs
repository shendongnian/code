    public class Repository
    {
        public T Create<T>(string id) where T : class
        {
            return Activator.CreateInstance(typeof(T), new[] { id }) as T;
        }
    }
