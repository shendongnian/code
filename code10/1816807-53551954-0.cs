    public class BaseClass
    {
        public BaseClass(string name)
        {
        }
    }
    public class DerivedClass: BaseClass
    {
        public DerivedClass() : base("test")
        {
        }
    }
