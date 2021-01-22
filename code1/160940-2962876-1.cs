    public class FooParameter : IParameter {
      string Data1 {get;set;}
    }
    
    public class FooOperationBase {
      protected readonly FooParameter m_Param;
      public FooOperationBase (FooParameter param) {
        m_Param = param;
      } 
    }
    
    public class FooOperation12 : FooOperationBase {
      public FooOperation12(FooParameter param) : base(param) {}
    
      public void DoSomeOperation() {
        return m_Param.Data1 + " transformed";
      }
    }
