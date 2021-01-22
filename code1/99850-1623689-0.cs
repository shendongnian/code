    public class AnonClass
    {
      ISharedServices _sharedServices;
      AnonClass(ISharedServices sharedServicesObj)
      {
        _sharedServices = sharedServicesObj;
      }
      public string GenerateCallId()
      {
        return "EX" + _sharedServices.GenerateId().ToString();
      }
    }
