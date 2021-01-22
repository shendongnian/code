    static void bar(object obj) {
      if (obj is IA && obj is IB) {
        foo(new ABWrapper((IA)obj)); 
      }
    }
