    interface IReadOnlyDic<Key, Value>
    {
        void Add(Key key, Value value);
    }
    class ReadOnlyDic<Key, Value> : Dictionary<Key, Value>, IReadOnlyDic<Key, Value>
    {
        public new void Add(Key key, Value value)
        {
            //throw an exception or do nothing
        }
        #region IReadOnlyDic<Key,Value> Members
    
        void IReadOnlyDic<Key, Value>.Add(Key key, Value value)
        {
            base.Add(key, value);
        }
    
        #endregion
    }
