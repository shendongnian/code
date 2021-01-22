    public class MyClass {
        public int Foo { get; private set; }
    
        public MyClass(int foo) {
            // oops, setting the parameter to itself, not the property
            foo = foo;
        }
    }
