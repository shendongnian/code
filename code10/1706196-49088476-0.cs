    public abstract class ParentClass
    {
        public INext ParentMethod()
        {
            ...
            return new ChildA(...);
        }
    }
    public interface INext
    {
        INext ChildAMethod1();
        INext ChildAMethod2();
    }
    public class ChildA : ParentClass, INext
    {
        public ChildA ChildAMethod1()
        {
            ... 
            return this; 
        }
        public ChildA ChildAMethod2() 
        {
            ... 
            return this; 
        }
    }
