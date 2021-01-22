      class Example {
        public T Method1<T>() {
          return default(T);
        }
        public T Method2<T>(T arg) {
          return arg;
        }
    
        public void Test() {
          int value1 = Method1();       // CS0411
          int value2 = Method1<int>();  // OK
          int value3 = Method2(42);     // Inferred, no problems
        }
      }
