    class Foo {
        public Foo() {
            Console.WriteLine("Foo ctor");
            SomeMethod(); // BAD IDEA (calling a virtual method in a ctor)
        }
        protected virtual void SomeMethod() {}
    }
    class Bar : Foo {
        protected override void SomeMethod() {
            Console.WriteLine("SomeMethod in Bar");
        }
        public Bar() : base() { /* only to show call order */
            Console.WriteLine("Bar ctor");
        }
    }
