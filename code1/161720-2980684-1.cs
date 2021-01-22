    // NOT A PRODUCTION-READY IMPLEMENTATION - DO NOT USE
    internal class LazyLoadList<T> : IList<T>
    {
        private IQueryable<T> query;
        private List<T> items;
        public LazyLoadList(IQueryable<T> query)
        {
            if (query == null)
                throw new ArgumentNullException("query");
            this.query = query;
        }
        private void Materialize()
        {
            if (items == null)
                items = query.ToList();
        }
        public void Add(T item)
        {
            Materialize();
            items.Add(item);
        }
        // Etc.
    }
