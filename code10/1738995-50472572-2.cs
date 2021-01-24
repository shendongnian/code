    public void UpdateEntitySet<T>(IEnumerable<object> models, IEnumerable<T> entities, string key) where T : class
    {
        Dictionary<object, T> entityDictionary = new Dictionary<object, T>();
        foreach(T entity in entities)
        {
            var entityKey = entity.GetType().GetProperty(key).GetValue(entity);
            entityDictionary.Add(entityKey, entity);
        }
        if (models != null)
        {
            foreach (object model in models)
            {
                var modelKey = model.GetType().GetProperty(key).GetValue(model);
                var existingEntity = entityDictionary.SingleOrDefault(d => Object.Equals(d.Key, modelKey)).Value;
                if (existingEntity == null)
                {
                    var newEntity = db.Set<T>().Create();
                    db.Set<T>().Add(newEntity);
                    db.Entry(newEntity).CurrentValues.SetValues(model);
                }
                else
                {
                    db.Entry(existingEntity).CurrentValues.SetValues(model);
                    entityDictionary.Remove(entityDictionary.Single(d => Object.Equals(d.Key, modelKey)).Key);
                }
            }
        }
        for (int i = 0; i < entityDictionary.Count; i++)
		    db.Entry(entityDictionary.ElementAt(i).Value).State = System.Data.Entity.EntityState.Deleted;
    }
