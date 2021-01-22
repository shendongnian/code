    public interface IFoo {}
    
    public abstract class MyClass<T>
        where T : class, IFoo
    {
    }
