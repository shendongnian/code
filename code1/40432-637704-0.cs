    public T GetItemById<T>(int id) where T : IIdentifiedEntity
    {
        Table<T> table = _db.GetTable<T>();
        return table.Where(t.Id == id)
                    .Single();
    }
