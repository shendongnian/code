    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class MyAttribute : Attribute
    {
        public MyAttribute(object a = null)
        {
        }
    }
    class Test
    {
        [My] // [My(a: "asd")]
        int prop1 { get; set; }
    }
