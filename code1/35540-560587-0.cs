    public class Foo {
      private class LazyLoader {
        private someType theValue;
        public someType Value {
          get {
            // Do lazy load
            return theValue;
          }
        }
      }
      private LazyLoader theValue;
      public someType {
        get { return theValue.Value; }
      }
    }
