    class Entity<T> where T : IPrimaryKey
    {
        public T Value {get; set;}
        public T OriginalValue {get; set;}
    }
    class ChangeTracker<T, TKey> where T: ICloneable
    {
        readonly Dictionary<int, Entity<T, TKey>> fetchedEntities = new Dictionary<int, Entity<T, TKey>>
        readonly List<T> itemsToAdd = new List<T>();
        public T Add(T item)
        {
            // TODO: check for not NULL, and Id == 0
            this.ItemsToAdd.Add(itemToAdd);
            return item;
        }
        public void Remove(T item)
        {
            // TODO: check not null, and primary key != 0
            Entity<T> entityToRemove = Find(item.Id);
            // TODO: decide what to do if there is no such item
            entityToRemove.Value = null;
            // null indicates it is about to be removed
        }
