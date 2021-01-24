    class DbRepoFactory
    {
        public static DbRepo<ICustomer DbRepo(Type entityType)
            where entityType : ICustomer
        {
             PropertyInfo idProperty = entityType.GetProperty("Id");
             // unsafe, compiler can't check that your type has a property Id
             Type idType = idProperty.PropertyType;
             if (idType == typeof(Guid)
                 return new DbRepo<GuidCustomer, Guid>();
                 // uses the first solution again
             else if (idType == typeof(int)
                 ...            
        }
    }
