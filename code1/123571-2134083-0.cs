    abstract class BaseCollection
    {
        private readonly Collection<BaseRecord> _realCollection = new Collection<BaseRecord>();
        public void Add(BaseRecord rec)
        {
            _realCollection.Add(rec);
        }
        public IEnumerable<BaseRecord> Items
        {
            get { return _realCollection; }
        }
    }
