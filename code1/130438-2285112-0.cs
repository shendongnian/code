    public static T GetService<T>()
    {
        Type serviceInterface = typeof(T);
        if (serviceInterface.Equals(typeof(IMemberService)))
        {
            return (T)(object)new MemberService();
        }
        else if (serviceInterface.Equals(typeof(ILookupService)))
        {
            return (T)(object)new LookupService();
        }
        throw new ArgumentOutOfRangeException("No action is defined for service interface " + serviceInterface.Name);
    }
