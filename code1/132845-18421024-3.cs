    public interface IExample
    {
        int ReadonlyValue { get; }
    }
    
    public class Example : IExample
    {
        public int Value { get; set; }
        public int ReadonlyValue { get { return this.Value; } }
    }
    
    
    public void Foo(IExample example)
    {
        // Now only has access to the get accessors for the properties
    }
