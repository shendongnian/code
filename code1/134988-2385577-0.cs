    class Foo {
        public int? a { get; set; }
        public int? b { get; set; }
        static void Main(string[] args) {
            var destObject = new Foo { a = 1, b = 2 };
            var sourceObject = new Foo { a = 110, b = 112 };
            var destProperty = typeof(Foo).GetProperty("b");
            var sourceProperty = typeof(Foo).GetProperty("a");
            destProperty.SetValue(destObject, sourceProperty.GetValue(sourceObject, null), null);
        }
    }
