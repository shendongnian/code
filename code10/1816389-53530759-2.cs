    public class Foo<TKey, TValue>
    {
        private readonly IFooDictionary<TKey, TValue> _dictionary;
        public Foo(IFooDictionary<TKey, TValue> dictionary)
        {
            _dictionary = dictionary;
        }
    }
