    public abstract class UniqueSet<T, TDictionary> : ICollection<T>
        where TDictionary : IDictionary<T, byte> {
    
        protected TDictionary _internalDictionary;
    
        protected UniqueSet(TDictionary dictionary) {
            _internalDictionary = dictionary;
        }
    
        // implement the ICollection<T> interface
        // using your internal dictionary's Keys property
        // for example:
        public void Add(T value) {
            _internalDictionary.Add(value, 0);
        }
        // etc.
    }
    public class UniqueSet<T> : UniqueSet<T, Dictionary<T, byte>> {
        public UniqueSet() : base(new Dictionary<T, byte>()) { }
    }
