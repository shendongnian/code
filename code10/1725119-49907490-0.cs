    public abstract class BaseClass
    {
        public abstract void DoSomething();
    }
    public class DerivedClass<T> : BaseClass
    {
        public DerivedClass(T initialValue)
        {
            Property = initialValue;
        }
        public T Property { get; set; }
        public override void DoSomething()
        {
            Console.WriteLine(Property);
        }
    }
    public class OtherDerivedClass<T> : BaseClass
    {
        public OtherDerivedClass(T initialValue)
        {
            OtherProperty = initialValue;
        }
        public T OtherProperty { get; set; }
        public int OtherProperty2 { get; set; }
        public override void DoSomething()
        {
            Console.WriteLine(OtherProperty);
        }
    }
