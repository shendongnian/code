    public class ListDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        new public List<TValue> this[TKey index]
        {
            get
            {
                List<TValue> list = null;
                if (!TryGetValue(index, out list))
                {
                    list = new List<TValue>();
                    Add(index, list);
                }
                return list;
            }
            set
            {
                if (ContainsKey(index))
                    base[index] = value;
                else
                    Add(index, value);
            }
        }
    }
