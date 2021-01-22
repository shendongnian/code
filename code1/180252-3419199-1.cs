    public interface IMySpecialInterface
    {
    }
    
    public interface IMySpecialInterface<X> : IMySpecialInterface
    {
    }
    
    public MyClass<T> : MyParentClass where T : IMySpecialInterface
    {
    }
