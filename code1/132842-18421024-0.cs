    public interface IExample
    {
        int ReadonlyValue { get; }
        string AnotherReadonlyValue { get; }
    }
    
    public class Example : IExample
    {
        public int Value { get; set; }
        public string AnotherValue { get; set; }
        public int ReadonlyValue { get { return this.Value; } }
        public string AnotherReadonlyValue { get { return this.AnotherValue; } }
    }
    
    
    public void Foo(IExample example)
    {
        // Now only has access to the get accessors for the properties
    }
