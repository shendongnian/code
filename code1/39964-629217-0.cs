    public class Foo
    {
      // Common implementation
    }
    
    public class Foo<T> : Foo
    {
       public Foo(T initialValue)
       {
          Value = initialValue;
       }
       public T Value { get; set; }
    }
