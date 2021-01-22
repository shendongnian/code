      class A : B
      {
        public A()
        {
          Foo(); // no warning
        }
    
        protected sealed override void Foo()
        {
          base.Foo();
        }
      }
