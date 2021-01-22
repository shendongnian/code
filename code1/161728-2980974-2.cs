    public class DynamicProxy : System.Dynamic.DynamicObject
    {
      private  object _inner;
      public DynamicProxy(object inner)
      { 
          _inner = inner;
      }
      public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
      {
        System.Diagnostics.Debug.WriteLine("Enter: ", binder.Name);
        bool returnValue = base.TryInvokeMember(binder, args, out result);
        System.Diagnostics.Debug.WriteLine("Exit: ", binder.Name);
        return returnValue;
      }   
    }
