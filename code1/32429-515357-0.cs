    public class BusinessObject
    {
      public static BusinessObjectFactory GetFactory()
      {
        return new BusinessObjectFactory (p => return new BusinessObject (p));
      }
      private BusinessObject(string property)
      {
      }
    }
    public class BusinessObjectFactory
    {
      private Func<string, BusinessObject> _ctorCaller;
      public BusinessObjectFactory (Func<string, BusinessObject> ctorCaller)
      {
        _ctorCaller = ctorCaller;
      }
    
      public BusinessObject CreateBusinessObject(string myProperty)
      {
        if (...)
          return _ctorCaller (myProperty);
        else
          return null;
      }
    }
:)
