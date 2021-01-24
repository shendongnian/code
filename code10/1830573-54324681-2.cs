    class DbSet<T> : IEnumerable<T>
    {
        private readonly Dictionary<int, T> fetchedItems = new Dictionary<int, T>();
        public T Find(int id)
        {
            if (!fetchedItems.TryGetValue(id, out T fetchedItem))
            {
                // fetch elements using ReadCsvFile and put them in the Dictionary
                // until you found the item with the requested primary key
                // or until the end of your sequence
            }
            return fetchedItem;
        }
    }
