    public void UpdateEntity<T>(int Id, string KeyPropertyName, string PropertyName, string PropertyValue) where T:class, new()
    {
        var entity = new T();
        typeof(T).GetProperty(KeyPropertyName).SetValue(entity,Id);
        this.Set<T>().Add(entity);
        var prop = typeof(T).GetProperty(PropertyName);
        var val = Convert.ChangeType(PropertyValue, prop.PropertyType);
        prop.SetValue(entity, val);
        this.Entry(entity).State = EntityState.Unchanged;
        foreach (var p in this.Entry(entity).Properties)
        {
            p.IsModified = p.Metadata.Name == PropertyName;
        }
        this.SaveChanges();
    }
