    DoSearch("foo", e => e.SomeProperty);
    // ...
    public void DoSearch<TKey>(string searchTerm, Func<MyEntity, TKey> orderBy)
    {
        IList<MyEntity> entities = GetCollectionOfEntities();
        IList<MyEntity> results = entities
                                  .Where(e => e.Description.Contains(searchTerm))
                                  .OrderBy(orderBy)
                                  .ToList();
        // etc
    }
