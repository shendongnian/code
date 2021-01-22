    //The one implementation of IParameter for all FooParameters
    public class FooParameter : IParameter {
      string Data1 {get;set;}
    }
    
    //base class for Foo Operation, only stores FooParameter 
    public class FooOperationBase {
      protected readonly FooParameter m_Param;
      public FooOperationBase (FooParameter param) {
        m_Param = param;
      } 
    }
    //specific operations on FooParameter go in this class
    public class FooOperation12 : FooOperationBase {
      public FooOperation12(FooParameter param) : base(param) {}
    
      public void DoSomeOperation() {
        return m_Param.Data1 + " transformed";
      }
    }
