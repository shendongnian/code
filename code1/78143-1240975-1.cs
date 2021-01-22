    [AttributeUsage(Inherited=true)]
    public class FooAttribute : System.Attribute
    {
        private string name;
    
        public FooAttribute(string name)
        {
            this.name = name;
        }
    
        public override string ToString() { return this.name; }
    }
    
    [Foo("hello")]
    public class BaseClass {}
    
    public class SubClass : BaseClass {}
    
    // outputs "hello"
    Console.WriteLine(typeof(SubClass).GetCustomAttributes(true).First());
