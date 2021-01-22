    public string GetDomainName<T>()
    {
        var dnAttribute = typeof(T).GetCustomAttribute<DomainNameAttribute>(true);
        if (dnAttribute != null)
        {
            return dnAttribute.Name;
        }
        return null;
    }
