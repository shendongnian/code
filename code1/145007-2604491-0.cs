    public interface IFoo<T>
    {
        void Process(T bar);
    }
    
    public abstract class FooBase<T> : IFoo<T>
?
