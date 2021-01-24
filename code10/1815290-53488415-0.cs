    class A
    {
      private B _b;
      public B b {
        get {
          if (_b == null) _b = new B();
          return _b;
        }
      }
      // Constructor can now be empty
      public A()
      {
      }
     }
