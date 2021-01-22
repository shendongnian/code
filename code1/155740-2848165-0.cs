    class A {
        protected void Foo() { … }
        protected int Bar() { … }
    }
    class B {
        private A a;
        public B() {
            this.a = new A();
        }
        protected int Bar() {
            return a.Bar();
        }
    }
    class C : B { … }
