    public interface IGenericDoSomething
    {
      void DoSomethingWithDefault();
    }
    
    public class GenericDerived<T> : BaseClass, IGenericDoSomething where T : struct
    {
      public T data;
      public void DoSomething<X>(X someParameter) => Console.WriteLine(someParameter);
        
      void IGenericDoSomething.DoSomethingWithDefault() => DoSomething(default(T)); 
    }
    
      public void Process<T>(T someObject) where T : BaseClass {
        switch (someObject)
        {
          case SimpleDerivedA a:
            a.DoSomething();
            break;
          case SimpleDerivedB b:
            b.DoSomething();
            break;
          case IGenericDoSomething g:
            g.DoSomethingWithDefault();
            break;
        }
      }
