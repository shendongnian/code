    public abstract class BaseClass
    {
        public abstract int Bar { get; }
    }
    public class ConcreteClass : BaseClass
    {
        public override int Bar { get; }
    
        public ConcreteClass(int bar)
        {
            Bar = bar;
        }
    }
