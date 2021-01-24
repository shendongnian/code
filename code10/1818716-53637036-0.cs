    [AttributeUsage(AttributeTargets.Class)]
    class SomeStringAttribute : Attribute
    {
        public string SomeString { get; set; }
        public SomeStringAttribute(string s)
        {
            SomeString = s;
        }
    }
    [SomeString("hello")]
    public class Class1
    { 
    } 
    
    [SomeString("world")]
    public class Class2
    { 
    }
    
    public class Testing<T>
    {
        public void Test()
        {
            string s =
                ((SomeStringAttribute)typeof(T).GetCustomAttributes(typeof(SomeStringAttribute),
                    false)[0]).SomeString;
        }
    }
