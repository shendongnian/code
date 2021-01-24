    public class RealmDictionary<T, K> : RealmObject 
    {
            public IList<T> Keys { get; }
            public IList<K> Values { get; }
    }
