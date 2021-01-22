    public class Foo {
        public Foo() : this("") {}
        public Foo (string name) {
            Name1 = name;
            Name2 = name;
        }
        // note only this will be serialized
        public string Name1 { get; private set; }
        // this won't
        private string Name2;
    }
