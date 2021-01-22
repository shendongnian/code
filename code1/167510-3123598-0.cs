    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Entity<string>>()
            {
                new Entity<string>("1", "Some data 1"),
                new Entity<string>("2", "Some data 2")
            };
            var myCollection = (MyDictionary<string, Entity<string>>)list;
        }
    }
    public class Entity<T> : IId<T>
    {
        private readonly T id;
        private string data;
        public Entity(T id, string data)
        {
            this.id = id;
            this.data = data;
        }
        public T Id
        {
            get { return id; }
        }
        public string Data
        {
            get { return data; }
            set { data = value; }
        }
    }
    public interface IId<T>
    {
        T Id { get; }
    }
    public class MyDictionary<TKey, TValue>
        where TValue : IId<TKey>
    {
        private readonly Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        public void Add(TKey key, TValue value)
        {
            dictionary.Add(key, value);
        }
        public bool Remove(TKey key)
        {
            var wasActuallyRemoved = dictionary.Remove(key);
            return wasActuallyRemoved;
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            var wasSuccessfull = dictionary.TryGetValue(key, out value);
            return wasSuccessfull;
        }
        public static explicit operator MyDictionary<TKey, TValue>(List<TValue> items)
        {
            var myDictionary = new MyDictionary<TKey, TValue>();
            foreach (var item in items)
            {
                myDictionary.Add(item.Id, item);
            }
            return myDictionary;
        }
    }
