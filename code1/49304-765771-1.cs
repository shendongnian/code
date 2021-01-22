    public class Tuple<T1,T2>
    {
      public T1 First {get;private set;}
      public T2 Second {get; private set;}
      Tuple(T1 first, T2 second)
      {
        First = first;
        Second = second;
      }
    }
    
    
    using ComplexPair = Tuple<bool,object>;
    
    public class SomeOtherClass 
    {
      public ComplexPair GetComplexType ()
      {
        ...
        return new ComplexPair(true, new object);
      }
    }
