    // Creates an instance of T that implements IBusinessRequest<R>
    public static IBusinessRequest<R> CreateBusinessInstance<T, R>() where T :
        IBusinessRequest<R>
    {
        return Activator.CreateInstance<T>();
    }
    // Creates an instance of businessType that implements 
    // IBusinessRequest<businessRequestType>
    public static object CreateBusinessInstance(Type businessType)
    {
        object biz = null;
        if (typeof(PersonBusiness) == businessType)
        {
            biz = CreateBusinessInstance<PersonBusiness, Person>();
        }
        //else if ... other business types
        
        if (null == biz)
        {
            throw new ApplicationException("Unknown type");
        }
        return biz;
    }
