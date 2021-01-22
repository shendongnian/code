    public class Foo<T>
    {
      public string Name {get;set;}
      public T Value {get;set;}
      public Type FooType
      {
         get
         {
           return typeof(T);
         }
      }
    }
