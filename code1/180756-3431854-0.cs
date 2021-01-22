    public class SysState {
      /* nothing much here, except...: */
      public abstract virtual void DoSomething();
    }
    
    public class Normal : SysState {
      /* properties & methods */
      public override void DoSomething()
      {
        // ...
      }
    }
    
    public class Foobar : SysState {
      /* different properties & methods */
      public override void DoSomething()
      {
        // ...
      }
    }
    
    SysState result = SomeFunctionThatReturnsObjectDerivedFromSysState();
    
    result.DoSomething();
