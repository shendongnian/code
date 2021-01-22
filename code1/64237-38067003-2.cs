    class Database
    {
        // Dictionary storing the classes using the non-generic base class
        private Dictionary<Type, Datatable> _tableDictionary;
		protected Database(List<Datatable> tables)
		{
            _tableDictionary = new Dictionary<Type, Datatable>();
            foreach (var table in tables)
            {
                _tableDictionary.Add(table.StoredClass, table);
            }
        }
        // Interface implementation, casts the generic
        public IDatatable<T> GetDataTable<T>()
        {
            Datatable table = null;
            _tableDictionary.TryGetValue(typeof(T), out table);
            return table as IDatatable<T>;
        }
    }
