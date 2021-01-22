    context.Customers.DeleteEntity(c => c.CustomerId, 12);
    public static class EntityExtensions
    {
        public static EntityKey CreateEntityKey<T, TId>(this ObjectSet<T> entitySet, Expression<Func<T, TId>> entityKey, TId id)
            where T : class
        {
            var qEntitySet = entitySet.Context.DefaultContainerName + "." + entitySet.EntitySet.Name;
            var keyName = LinqHelper.PropertyName(entityKey);
            return new EntityKey(qEntitySet, keyName, id);
        }
        public static void DeleteEntity<T, TId>(this ObjectSet<T> entitySet, Expression<Func<T, TId>> entityKey, TId id) 
            where T : EntityObject, new()
        {
            var key = CreateEntityKey(entitySet, entityKey, id);
            var entityInstance = new T {EntityKey = key};
            var propertyName = LinqHelper.PropertyName(entityKey);
            var property = typeof (T).GetProperty(propertyName);
            if (property == null)
                throw new Exception("Property name " + propertyName + " does not exist on " + typeof(T).Name);
            property.SetValue(entityInstance, id, null);
            entitySet.Attach(entityInstance);
            entitySet.DeleteObject(entityInstance);
        }
