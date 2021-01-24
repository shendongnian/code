    public DataAccess
    {
        public DataAccess()
        {
            Inventories = GetIventory();
        }
        public IEnumerable Inventories { get; private set; }
       //...
    }
