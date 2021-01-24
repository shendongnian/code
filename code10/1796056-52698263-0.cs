    public class Foo
    {
        public int Id { get; set; }
    
        public string Bar { get; set; }
        public string FooBar { get; set; }
        public string Fizz { get; set; }
        public string Buzz { get; set; }
    
        private static Dictionary<string, Action<Foo, string>> _propertySetters =
            new Dictionary<string, Action<Foo, string>>()
            {
                { "Bar", (foo, value) => foo.Bar = value },
                { "FooBar", (foo, value) => foo.FooBar = value },
                { "Fizz", (foo, value) => foo.Fizz = value },
                { "Buzz", (foo, value) => foo.Buzz = value },
            };
    
        public static Foo CreateWithProperty(int id, string property, string value)
        {
            if (String.IsNullOrEmpty(property) || !_propertySetters.ContainsKey(property))
                throw new ArgumentException("property");
    
            var instance = new Foo { Id = id };
    
            var setter = _propertySetters[property];
    
            setter(instance, value);
    
            return instance;
        }
    }
