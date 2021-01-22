    class A {
      private B b;
      private EventHandler eventA;
      public event EventHandler EventA {
        add {
          eventA += value;
          b.EventB += value;
        }
        remove {
          eventA -= value;
          b.EventB -= value;
        }
      }
      public A() {
        b = new B();
      }
      // ...
    }
