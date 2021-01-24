    public interface INext
    {
        INext ChildAMethod1();
        INext ChildAMethod2();
    }
    public abstract class ParentClass
    {
        public INext ParentMethod()
        {
            ...
            return new ChildA(...);
        }
    }
    public class ChildA : ParentClass, INext
    {
        public INext ChildAMethod1()
        {
            ... 
            return this; 
        }
        public INext ChildAMethod2() 
        {
            ... 
            return this; 
        }
    }
