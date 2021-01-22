    class StringHolder {
        public string Value { get; set; }
    }
    class Foo {
        private StringHolder holder = new StringHolder();
        public string Value  {
           get { return holder.Value; }
           set { holder.Value = value; }
        }
        public Foo() { }
        // this constructor creates a "linked" Foo
        public Foo(Foo other) { this.holder = other.holder; } 
    }
    // .. later ...
    Foo a = new Foo { Value = "moose" };
    Foo b = new Foo(a); // link b to a
    b.Value = "elk"; 
    // now a.Value also == "elk"
    a.Value = "deer";
    // now b.Value also == "deer"
