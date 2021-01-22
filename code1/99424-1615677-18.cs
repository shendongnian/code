    public partial class MyWebService :
        System.Web.Services.Protocols.SoapHttpClientProtocol 
    {
        ...
        public string DoSomething () { ... }
    }
    public class MyClient
    {
        public void CallService ()
        {
            MyWebService client = new MyWebService ();
            client.DoSomething ();
        }
    }
