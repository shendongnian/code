    public class Foo {
        [Required]
        public string Name { get; set; }
    }
    [AttributeProvider(typeof(Foo))]
    public class Bar {
        public string Name { get; set; }
    }
