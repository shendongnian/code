    IRepository<T> GetRepository() where T : Parent
    {
        if (typeof(Child).IsAssignableFrom(T))
        {
            Type childType = typeof(T);  // which is both, Parent and Child
            Type classType = typeof(ChildRepository<>);
            Type[] typeParams = { childType };
            Type repositoryType = classType.MakeGenericType(typeParams);
            return Activator.CreateInstance(resultType) as IRepository<T>;
        }
        return new Repository<T>();
    }
