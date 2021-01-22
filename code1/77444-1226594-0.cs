    public interface IFoo
    {
    ...
    }
    
    public interface IFooWrapper : IFoo
    {
    ...
    }
    public interface IFooWrapper<T> : IFooWrapper
     where T : IFoo
    {
    ...
    }
    IList<IFooWrapper> myList;
