    class A {
        protected virtual void Foo() {
            Console.WriteLine("I'm A");
        }
    }
    
    class B : A {
        protected override void Foo() {
            Console.WriteLine("I'm B");
        }
        
        public void Bar() {
            Foo();
            base.Foo();
        }
    }
