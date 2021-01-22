    abstract public class Foo
    {
      // Common implementation
      abstract public object ObjectValue { get; }
    }
    
    public class Foo<T> : Foo
    {
       public Foo(T initialValue)
       {
          Value = initialValue;
       }
 
       public T Value { get; set; }
       public object ObjectValue
       { 
          get { return Value; }
       }
    }
