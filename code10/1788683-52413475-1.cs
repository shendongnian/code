      public static class IntExtensions {
        public static int increment(this int value) {
          return value + 1; 
        }
      }
     ...
     // Syntax sugar: the actual call is "int foo = IntExtensions.increment(9);"
     var foo = 9.increment();
