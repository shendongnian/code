    class Outer {
      private Outer() {
      }
      public Outer Create() { return new Outer(); }
      class Inner() { 
        void Function1() { new Outer(); }
        class DoubleInner() {
           void Function2() { new Outer(); }
        }
      }
    }
  
