    public static class RepositoryExtensions
    {
        public static T LocalContextEntitiesFinder<T>(this TenantContext context, Guid id) where T : class, ISomeInterfaceThatAllYourDBModelsImplements, new()
        {
            var localObj = context.Set<T>().Local.FirstOrDefault(entry => entry.Id.Equals(id));
            if (localObj != null)
            {
                return localObj;
            }
            localObj = new T
            {
                Id = id
            };
            context.Set<T>().Attach(localObj);
            return localObj;
        }
    }
