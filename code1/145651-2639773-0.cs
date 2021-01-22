    public class SoapClient : SoapHttpClientProtocol
    {
        public SoapClient()
        {
        }
        public object[] Invoke(string method, object[] args)
        {
            return base.Invoke(method, args);
        }
    }
