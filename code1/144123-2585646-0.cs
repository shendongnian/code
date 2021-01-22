    class Foo
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop3 { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo
            {
                Prop1 = (string)null,
                Prop2 = (string)null,
                Prop3 = (string)null,
            };
    
            var props = typeof(Foo).GetProperties()
                .Where(x => x.PropertyType == typeof(string));
            foreach (var p in props)
            {
                p.SetValue(foo, string.Empty, null);
            }
        }
    }
