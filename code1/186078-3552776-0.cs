    class Test {
      class System {}
      public void Example() {
        System.Console.WriteLine("here"); // Error since System binds to Test.System
        global::System.Console.WriteLine("here"); // Works
    }
