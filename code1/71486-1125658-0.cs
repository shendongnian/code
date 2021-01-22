    public class MyClass
    {
        public virtual int Value { get { return 10; } }
    }
    public class MyOtherClass : MyClass
    {
        public override int Value { get { return 20; } }
    }
