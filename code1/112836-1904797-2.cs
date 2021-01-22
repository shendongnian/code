    public static IBaseRepository<TClass> GetRepository<TClass>()
      where TClass : IDataEntity
    {
        Type t = typeof(TClass);
        RepositoryAttribute attr =
            (RepositoryAttribute)Attribute.GetCustomAttribute(t,
              typeof(RepositoryAttribute), false);
        if (attr != null)
        {
            return (IBaseRepository<TClass>)Activator.CreateInstance(attr.RepositoryType);
        }
        return null;
    }
