    [SerializableAttribute]
    [ComVisibleAttribute(false)]
    public class Dictionary<TKey, TValue> : IDictionary<TKey, TValue>, 
        ICollection<KeyValuePair<TKey, TValue>>,
        IEnumerable<KeyValuePair<TKey, TValue>>, 
        IDictionary, ICollection, IEnumerable,
        ISerializable, IDeserializationCallback
