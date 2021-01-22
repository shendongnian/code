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
        protected TestClass()
        { }
    }
    TestClass.Add(3.0, 4.0)
    TestClass<int>.Add(3, 4)
