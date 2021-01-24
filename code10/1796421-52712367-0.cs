      public class SomeClass
      {
        public X x;
      }
    
      public class X
      {
        public int i; // I added this int to verify which X object we're working with.
        public X(int i)
        {
          this.i = i;
        }
      }
