    // Creates an instance of T that implements IBusinessRequest<R>
    public static IBusinessRequest<R> CreateBusinessInstance<T, R>() where T : IBusinessRequest<R>
    {
        return Activator.CreateInstance<T>();
    }
    // Creates an instance of PersonBusiness that implements IBusinessRequest<businessRequestType>
    public static object CreatePersonBusiness(Type businessRequestType)
    {
        object biz = null;
        if (typeof(Person) == businessRequestType)
        {
            biz = CreateBusinessInstance<PersonBusiness, Person>();
        }
        // else if ... other businessRequestType options
        return biz;
    }
    // Creates an instance of businessType that implements 
    // IBusinessRequest<businessRequestType>
    public static object CreateBusinessInstance(Type businessType, Type businessRequestType)
    {
        object biz = null;
        if (typeof(PersonBusiness) == businessType)
        {
            biz = CreatePersonBusiness(businessRequestType);
        }
        //else if ... other types 
        
        if (null == biz)
        {
            throw new ApplicationException("Unknown type");
        }
        return biz;
    }
