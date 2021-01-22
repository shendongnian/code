    public class LastDictionary<TKey, TValue>
    {
    private Dictionary<TKey, TValue> dict;
    private TKey lastKey;
    private TValue lastValue;
    public LastDictionary()
    {
        dict = new Dictionary<TKey, TValue>();
    }
    public void Add(TKey key, TValue value)
    {
        lastKey = key;
        lastValue = value;
        dict.Add(key, value);
    }
    public TKey LastKey
    {
        get { return lastKey; }
    }
    public TValue LastValue
    {
        get { return lastValue; }
    }
    }
