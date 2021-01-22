    public enum ReturnIdentifier {
      Success = 100,
      MissingName = 201;
    }
    
    public class ReturnCode {
    
      public ReturnIdentifier Code { get; private set; }
    
      public ReturnCode(ReturnIdentifier code) {
        Code = code;
      }
    
      public string Message {
        get {
          switch (Code) {
            case ReturnIdentifier.Success:
              return "Request completed successfuly.";
            case ReturnIdentifier.MissingName:
              return "Missing name in request.";
            default:
              return "Unexpected failure, please email for support.";
          }
        }
      }
    
    }
