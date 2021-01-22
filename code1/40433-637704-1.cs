    public T GetItemById<T>(int id) where T : class, IIdentifiedEntity
    {
        Table<T> table = _db.GetTable<T>();
        return table.Where(t => t.Id == id)
                    .Single();
    }
