    public class MyClass {
        Foo _foo;
        Bar _bar;
        Baz _baz;
        public MyClass(Foo foo, Bar bar, Baz baz) {
            _foo = foo;  _bar = bar; _baz = baz;
        }
        public MyClass(Foo foo, Bar bar) : this(foo, bar, new Baz()) { }
        
        public MyClass(Foo foo) : this(foo, new Bar()) { }
      
        public MyClass() : this(new Foo()) { }
    }
