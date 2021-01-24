    class Foo {
        public int I { get; }
        // some more properties...
        public Foo(int i) { 
            this.I = i; 
            // a few other properties are set here
        }
        public Foo() : this(GetBar()) {} // this line gives you an error
        public int Get5() {
            // Here is looks at some other properties of Foo and returns something based on that
        }
    }
