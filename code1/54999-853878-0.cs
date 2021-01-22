    class ReadOnlyDic<Key, Value> : Dictionary<Key, Value>
    {
        private bool _locked = false;
    
        public new void Add(Key key, Value value)
        {
            if (!_locked)
            {
                base.Add(key, value);
            }
            else
            {
                throw new ReadOnlyException();
            }
        }
        public void Lock()
        {
            _locked = true;
        }
    }
