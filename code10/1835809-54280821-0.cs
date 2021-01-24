    TextMessageEncodingBindingElement tmebe = new TextMessageEncodingBindingElement();
    tmebe.MessageVersion = MessageVersion.Soap12;
    TransportBindingElement tbe = new HttpTransportBindingElement();
    CustomBinding binding = new CustomBinding(new BindingElement[] { tmebe, tbe });
    EndpointAddress endpointAddress = new EndpointAddress("http://localhost/TestWebService/WebService1.asmx");
    using (WebService1SoapClient client = new WebService1SoapClient(binding, endpointAddress))
    {
        String result = client.HelloWorld();
        Debug.WriteLine(result);
    }
