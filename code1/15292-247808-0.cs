    public partial class MyWebService : System.Web.Services.Protocols.SoapHttpClientProtocol 
    {
       public override MyWebService(int dummy) 
       { 
             string myString = "overridden constructor";
             //other code...
       }
    }
    MyWebService mws = new MyWebService(0);
