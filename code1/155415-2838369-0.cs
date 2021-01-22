    static IRepository<T> IRepositorySource.GetNew<T>()
    {
        if (typeof(T) == typeof(ISomeEntity))
           return (IRepository<T>)new SomeEntityRepository();
        ...
    }
}
 
