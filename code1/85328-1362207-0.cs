    public partial class ListIncomeWeight : SortedDictionary<string, double>
    {
        public delegate void ChangedHandler();
        public event ChangedHandler Changed;
        private Guid _guid;
        private bool _changed = false;
        private void RaiseChanged()
        {
            _changed = true;
            if (Changed != null) Changed();
        }
        public new void Add(string key, double value)
        {
            base.Add(key, value);
            RaiseChanged();
        }
        public new void Clear()
        {
            base.Clear();
            RaiseChanged();
        }
        public new bool Remove(string key)
        {            
            bool res = base.Remove(key);
            RaiseChanged();
            return res;
        }
        public Guid Identity
        {
            get
            {
                if (_changed)
                {
                    _guid = new Guid();
                    _changed = false;
                }
                return _guid;
            }
            set {
                _guid = value;
            }
        }        
    }
