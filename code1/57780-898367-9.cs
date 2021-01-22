    public static class EfExtensions
    {
      public static void ApplyDetachedPropertyChanges<T>(this ObjectContext db, T entity, Func<T, int> getIdDelegate)
      where T : EntityObject
      {
        var entitySetName = db.DefaultContainerName + "." + entity.GetType().Name;
        var id = getIdDelegate(entity);
        var entityKey = new EntityKey(entitySetName, "Id", id);
    
        db.Attach(new Department {Id = id, EntityKey = entityKey});
        db.AcceptAllChanges();
        
        db.ApplyPropertyChanges(entitySetName, entity);
      }
    }
