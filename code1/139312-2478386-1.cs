    public class BaseProxy
    {
       private Base _base;
       private B _runningBase;
       public BaseProxy(B b)
       {
          _base = new Base();
          _runningBase = b; 
       }
       public static implicit operator Base(BaseProxy proxy)
       {
          return (State == Running) ? proxy._runningBase : proxy._base;
       }
    }
    
