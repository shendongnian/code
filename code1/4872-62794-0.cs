    public class MyService : SoapHttpClientProtocol
    {
        public MyService(string url)
        {
            this.Url = url;
            // plus set credentials, etc.
        }
        [SoapDocumentMethod("{service url}", RequestNamespace="{namespace}", ResponseNamespace="{namespace}", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int MyMethod(string arg1)
        {
            object[] results = this.Invoke("MyMethod", new object[] { arg1 });
            return ((int)(results[0]));
        }
    }
