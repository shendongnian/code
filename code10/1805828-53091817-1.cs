    public abstract class Base
    {
        protected string MyProperty { get; }
        public Base(string myProperty)
        {
            MyProperty = myProperty;
        }
    }
    public class Derived : Base
    {
        public Derived()
            : base("DefaultValue")
        { }
    }
