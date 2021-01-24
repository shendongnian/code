    internal interface IKey
    {
        string Name { get; }
    }
    public sealed class Key<T> : IKey
    {
        public string Name { get; }
        public Key(string name)
        {
            Name = name;
        }
    }
    public sealed class SmartDict
    {
        private readonly Dictionary<IKey, object> Values = new Dictionary<IKey, object>();
        public T Get<T>(Key<T> key)
        {
            if (Values.TryGetValue(key, out object value)) {
                return (T)value;
            }
            throw new KeyNotFoundException($"'{key.Name}' not found.");
        }
        public void Set<T>(Key<T> key, T value)
        {
            Values[key] = value;
        }
    }
