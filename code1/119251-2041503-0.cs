    DoSearch("foo", e => e.SomeProperty);
    // ...
    public void DoSearch<TKey>(string searchTerm, Func<MyEntity, TKey> keySelector)
    {
        IList<MyEntity> entities = GetCollectionOfEntities();
        IList<MyEntity> results = entities
                                  .Where(e => e.Description.Contains(searchTerm))
                                  .OrderBy(keySelector)
                                  .ToList();
        // ...
    }
