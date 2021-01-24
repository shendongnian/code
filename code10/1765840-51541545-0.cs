    public class Request {
      public string Username { get; set; } // log this
      public string Password { get; set; } // but not this
    }
    
    public class RequestLogWrapper {
      public Request WrappedRequest { private get; set; }
      public String Username { get { return WrappedRequest.Username; }
    }
    //To use:
    var rlw = new RequestLogWrapper { Request = request };
    logger.log("Got a request: {0}", rlw);
