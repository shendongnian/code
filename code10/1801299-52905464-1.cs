    public class Foo { }
    public class Foo1 : Foo { }
    public class Foo2 : Foo { }
    
    public class SomeClass
    {    
       public static int Method<T>(Dictionary<int, T> dict) where T : Foo
       {
          ...
       }
    }
