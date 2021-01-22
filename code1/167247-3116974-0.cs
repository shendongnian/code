    class Test
    {
        [InlineData]
        [InlineData]
        static void Main() { }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    class DataAttribute : Attribute {}
    class InlineDataAttribute : DataAttribute { }
