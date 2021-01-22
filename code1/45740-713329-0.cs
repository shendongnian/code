    using System;
    class Foo {
        int Bar() { return 1; }
        void Bar(int a) { }
        static void Main() {
            Foo foo = new Foo();
            Func<int> myDelegate = foo.Bar; // points to "int Bar()" version
        }
    }
