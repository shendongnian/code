    var sortedOC = _collection.OrderBy(i => i.Key);
    private void doSort()
    {
        ObservableCollection<Pair<ushort, string>> _collection = 
            new ObservableCollection<Pair<ushort, string>>();
        _collection.Add(new Pair<ushort,string>(7,"aaa"));
        _collection.Add(new Pair<ushort, string>(3, "xey"));
        _collection.Add(new Pair<ushort, string>(6, "fty"));
        var sortedOC = from item in _collection
                       orderby item.Key
                       select item;
        foreach (var i in sortedOC)
        {
            Debug.WriteLine(i);
        }
    
    }
    public class Pair<TKey, TValue>
    {
        private TKey _key;
        public TKey Key
        {
            get { return _key; }
            set { _key = value; }
        }
        private TValue _value;
        public TValue Value
        {
            get { return _value; }
            set { _value = value; }
        }
        
        public Pair(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }
        public override string ToString()
        {
            return this.Key + ":" + this.Value;
        }
    }
