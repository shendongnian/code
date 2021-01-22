    class Foo {
        public int i; // yes, a public field
        public void SomeMethod() {i++;}
    }
    ...
    Foo foo = new Foo();
    foo.i = 1;
    Action action = foo.SomeMethod;
    action();
