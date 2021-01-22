    class Test<T> where T : class {
      public void Write<U>(U arg1) {
        Console.WriteLine(arg1.ToString());
      }
    }
