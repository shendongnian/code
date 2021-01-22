    public interface IDeepCopyable {
        object DeepCopy();
    }
    public class Cache<TKey, TValue> where TValue : IDeepCopyable {
        Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
        // omit dictionary-manipulation code
        public TValue this[TKey key] {
            get {
                return dictionary[key].DeepCopy(); // could use reflection to clone too
            }
        }
    }
