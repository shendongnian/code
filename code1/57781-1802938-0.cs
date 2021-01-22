    public static class EfExtensions
    {
        public static void ApplyDetachedPropertyChanges<T>(this ObjectContext db, T entity, Func<T, int> getIdDelegate)
        where T : EntityObject
        {
            var entitySetName = db.DefaultContainerName + "." + entity.GetType().Name;
            
            T newEntity = Activator.CreateInstance<T>();
            newEntity.EntityKey = db.CreateEntityKey(entitySetName, entity);
            
            Type t = typeof(T);
            foreach(EntityKeyMember keyMember in newEntity.EntityKey.EntityKeyValues) {
                PropertyInfo p = t.GetProperty(keyMember.Key);
                p.SetValue(newEntity, keyMember.Value, null);
            }
            db.Attach(newEntity);
            //db.AcceptAllChanges();
            db.ApplyPropertyChanges(entitySetName, entity);
        }
    }
