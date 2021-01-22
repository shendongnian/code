    public static class TestClass<T>
    {
        public static T Add(T x, T y)
        {
            return (dynamic)x + (dynamic)y;
        }
    }
    public static class TestClass : TestClass<double>
    {
    }
