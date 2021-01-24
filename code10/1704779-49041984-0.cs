    public interface ICache
    {
        T Get<T>(string key);
        void Set(string key, object value);
    }
