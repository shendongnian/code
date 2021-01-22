    // Definitions.cs
    public interface IData { }
    public delegate IData Foo(IData input);
    public delegate IData Bar<T>(IData input, T extraInfo);
    public delegate Foo Produce<T>(Bar<T> next);
    // Test.cs
    class Test
    {
        static void Main()
        {
            Produce<string> produce = 
                next => input => next(input, "This string should appear.");
        }    
    }
