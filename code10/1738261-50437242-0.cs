    public interface DepInterfaceOne
    {
        int MethodWithCachedData();
        void InfoRequiredForAtRunTime(object RunTimeObject);
    }
    public interface DepInterfaceTwo: IConsistencyCheckCacheHelper
    {
    }
