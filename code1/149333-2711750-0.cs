    [XmlRpcUrl("http://localhost:8080/xmlrpc")]
    public interface IMath : IXmlRpcProxy
    {
        [XmlRpcMethod("app.getName")]
        string GetName(string number);
    }
    public string GetName(string keyInput)
    {
            var  mathProxy = XmlRpcProxyGen.Create<IMath>();
            mathProxy.Url = "http://localhost:8080/xmlrpc/";
            return mathProxy.GetName(keyInput);
         
    }
