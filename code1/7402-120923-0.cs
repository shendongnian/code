      class B
      {
        protected virtual void Foo() { }
      }
    
      class A : B
      {
        public A()
        {
          Foo(); // warning here
        }
      }
