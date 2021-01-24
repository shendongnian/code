    public void UpdateEntity<T>(int id, string propertyName, string propertyValue) where T:class
    {
        var entity = this.Set<T>().Find(id);
        var prop = typeof(T).GetProperty(propertyName);
        var val = Convert.ChangeType(propertyValue, prop.PropertyType);
        prop.SetValue(entity, val);
        this.SaveChanges();
    }
