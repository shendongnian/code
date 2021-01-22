    public class BaseClass
    {
        public BaseClass(XElement defintion)
        {
            // base class loads state here
        }
    }
    public class DerivedClass : BaseClass
    {
        public DerivedClass (XElement defintion)
            : base(definition)
        {
            // derived class loads state here
        }
    }
