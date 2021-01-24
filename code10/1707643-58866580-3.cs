    public class RealmDictionary<T> : RealmObject 
    {
        public IList<T> Keys { get; }
        public IList<T> Values { get; }
    }
