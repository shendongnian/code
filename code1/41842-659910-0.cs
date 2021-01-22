     public class RequestArgs { } 
     public class Request 
     {  // ...
         void virtual SendRequest(RequestArgs args);
     }
     // ----------------------------
     public class UpdateArgs : RequestArgs 
     { 
          public string SessionID {get; set;}
     }  
     class UpdateCustomerRequest : Request
     {  // ...
         void SendRequest(RequestArgs args)
         {
            UpdateArgs updateArgs = args as UpdateArgs ;
           // :
         }
     }
