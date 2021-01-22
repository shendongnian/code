    class ParameterizedKeyNotFoundException<T> : KeyNotFoundException {
        public T InvalidKey { get; private set; }
        public ParameterizedKeyNotFoundException(T InvalidKey) {
            this.InvalidKey = InvalidKey;
        }
    }
    static class Program {
        static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> Dict, TKey Key) {
            TValue res;
            if (Dict.TryGetValue(Key, out res))
                return res;
            throw new ParameterizedKeyNotFoundException<TKey>(Key);
        }
        static void Main(string[] args) {
            var x = new Dictionary<string, int>();
            x.Add("foo", 42);
            try {
                Console.WriteLine(x.Get("foo"));
                Console.WriteLine(x.Get("bar"));
            }
            catch (ParameterizedKeyNotFoundException<string> e) {
                Console.WriteLine("Invalid key: {0}", e.InvalidKey);
            }
            Console.ReadKey();
        }
    }
