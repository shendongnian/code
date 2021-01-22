    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class MyAttribute : Attribute
    {
        public MyAttribute()
        {
        }
        public object a { get; set; }
    }
    class Test
    {
        [My] // [My(a=null)]
        int prop1 { get; set; }
    }
