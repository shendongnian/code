    service MyService {
      rpc myFunction(stream MyMessage) returns (stream MyResponse)
    }
    message MyMessage {
      string user = 1;
      string password = 2;
      int32 myMessageVariable = 3;
    }
