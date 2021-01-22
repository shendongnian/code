    public static void ApplyDetachedPropertyChanges<T>(this ObjectContext db, T entity) where T : EntityObject
    {
        PropertyInfo idProperty = typeof(T).GetProperty("Id");
        var entitySetName = db.DefaultContainerName + "." + entity.GetType().Name;
        var id = idProperty.GetValue(entity, null);
        var entityKey = new EntityKey(entitySetName, "Id", id);
        Type type = entity.GetType();
        EntityObject obj = (EntityObject)Activator.CreateInstance(type);
        idProperty.SetValue(obj, id, null);
        obj.EntityKey = entityKey;
        db.Attach(obj);
        db.AcceptAllChanges();
        db.ApplyCurrentValues(entitySetName, entity);
    }
