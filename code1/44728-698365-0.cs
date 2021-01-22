    public IQueryable<T> GetQuery<T>()
    {
        Type baseType;
        if (HasBaseType(typeof(T), out baseType))
        {
            return this.ObjectContext.CreateQuery<T>(String.Format("[{0}]", baseType.Name.ToString())).OfType<T>();
        }
        else
        {
            return this.ObjectContext.CreateQuery<T>(String.Format("[{0}]", baseType.Name.ToString()));
        }
    }
