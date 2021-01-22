    public class TestClass<T>
    {
        protected TestClass()
        { }
        public static T Add(T x, T y)
        {
            return (dynamic)x + (dynamic)y;
        }
    }
    public class TestClass : TestClass<double>
    {
        // Inherited classes will also need to have protected constructors to prevent people from creating instances of them.
        protected TestClass()
        { }
    }
    TestClass.Add(3.0, 4.0)
    TestClass<int>.Add(3, 4)
    // Creating a class instance is not allowed because the constructors are inaccessible.
    // new TestClass();
    // new TestClass<int>();
