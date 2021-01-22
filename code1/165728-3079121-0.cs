    class A {
      private B b;
      public event EventHandler EventA {
        add {
          b.EventB += value;
        }
        remove {
          b.EventB -= value;
        }
      }
      public A() {
        b = new B();
      }
      // ...
    }
