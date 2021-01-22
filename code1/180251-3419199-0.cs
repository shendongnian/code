    public interface IMySpecialInterface
    {
    }
    
    public interface IMySpecialInterface<X>
    {
    }
    
    public MyClass<T> : MyParentClass where T : IMySpecialInterface
    {
    }
