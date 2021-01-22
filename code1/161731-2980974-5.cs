    public class DynamicProxy : System.Dynamic.DynamicObject
    {
      private object _innerObject;
      private Type _innerType;
      public DynamicProxy(object inner)
      {
        if (inner == null) throw new ArgumentNullException("inner");
        _innerObject = inner;
        _innerType = _innerObject.GetType();
      }
      public override bool TryInvokeMember(System.Dynamic.InvokeMemberBinder binder, object[] args, out object result)
      {
        System.Diagnostics.Debug.WriteLine("Enter: ", binder.Name);
        try
        {
          result = _innerType.InvokeMember(
            binder.Name,
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.InvokeMethod,
            null, _innerObject, args);
        }
        catch (MissingMemberException)
        {
          return base.TryInvokeMember(binder, args, out result);
        }
        finally
        {
          System.Diagnostics.Debug.WriteLine("Exit: ", binder.Name);
        }
        return true;
      }
      public override bool TryGetMember(System.Dynamic.GetMemberBinder binder, out object result)
      {
        System.Diagnostics.Debug.WriteLine("Enter: ", binder.Name);
      
        try
        {
        result = _innerType.InvokeMember(
          binder.Name,
          BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty,
          null, _innerObject, null);
        }
        catch (MissingMemberException)
        {
          return base.TryGetMember(binder, out result);
        }
        finally
        {
          System.Diagnostics.Debug.WriteLine("Exit: ", binder.Name);
        }
        return true;
      }    
      public override bool TrySetMember(System.Dynamic.SetMemberBinder binder, object value)
      {
        System.Diagnostics.Debug.WriteLine("Enter: ", binder.Name);
        try
        {
        _innerType.InvokeMember(
          binder.Name,
          BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty,
          null, _innerObject, new object[]{ value });
        }
        catch (MissingMemberException)
        {
          return base.TrySetMember(binder, value);
        }
        finally
        {
          System.Diagnostics.Debug.WriteLine("Exit: ", binder.Name);
        }      
        return true;
      }
      public override string ToString()
      {
        try
        {
          System.Diagnostics.Debug.WriteLine("Enter: ToString");
          return _innerObject.ToString();
        }
        finally
        {
          System.Diagnostics.Debug.WriteLine("Exit: ToString");
        }
      }
    }
