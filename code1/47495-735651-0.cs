      public class Foo
      {
        ...
      }
      public class Bar : Foo
      {
        ...
      }
      var list = new LinkedList<Bar>();
      .... make list....
      
      foreach (var foo in list.Cast<Foo>())
      {
          ...
      }
