    public void UpdateEntity<T>(int id, string keyPropertyName, string propertyName, string propertyValue) where T:class, new()
    {
        var entity = new T();
        typeof(T).GetProperty(keyPropertyName).SetValue(entity,Id);
        this.Set<T>().Add(entity);
        var prop = typeof(T).GetProperty(propertyName);
        var val = Convert.ChangeType(propertyValue, prop.PropertyType);
        prop.SetValue(entity, val);
        this.Entry(entity).State = EntityState.Unchanged;
        foreach (var p in this.Entry(entity).Properties)
        {
            p.IsModified = p.Metadata.Name == propertyName;
        }
        this.SaveChanges();
    }
