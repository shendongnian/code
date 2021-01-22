      class Test {
        int notAssigned;
        void method() {
          // Use it, but don't initialize it
          int ix = notAssigned;
        }
      }
