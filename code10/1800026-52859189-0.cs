    public void UpdateEntity<T>(int Id, string PropertyName, string PropertyValue) where T:class
    {
        var entity = this.Set<T>().Find(Id);
        var prop = typeof(T).GetProperty(PropertyName);
        var val = Convert.ChangeType(PropertyValue, prop.PropertyType);
        prop.SetValue(entity, val);
        this.SaveChanges();
    }
