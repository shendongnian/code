    class Example {
      public static string NonInstanceMethod() {
        return "static";
      }
      public string InstanceMethod() { 
        return "non-static";
      }
    }
    
    static void SomeMethod() {
      Console.WriteLine(Example.NonInstanceMethod());
      Console.WriteLine(Example.InstanceMethod());  // Does not compile
      Example v1 = new Example();
      Console.WriteLine(v1.InstanceMethod());
    }
 
