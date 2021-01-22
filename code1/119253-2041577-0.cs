        public void DoSearch(string searchTerm, Func<MyEntity, PropertyType> selector)
        {
           IList<MyEntity> entities = GetCollectionOfEntities();
           IList<MyEntity> results = entities
                          .Where(d => d.Description.Contains(searchTerm))
                          .OrderBy(selector)
                          .ToList();
       }
       DoSearch("searchTerm", entity => entity.Property)
