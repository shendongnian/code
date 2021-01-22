     public class MyWebService : System.Web.Services.WebService, IMyWsdlInterface
     {    
         [WebMethod]
         public string GetSomeString()
         {
             //you'll have to write your own business logic 
             return "Hello SOAP World";
         }
     }
