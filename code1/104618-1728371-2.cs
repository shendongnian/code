    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                // read the raw SOAP request message from a file
                var data = File.ReadAllText("request.xml");
                // the Content-Type needs to be set to XML
                client.Headers.Add("Content-Type", "text/xml;charset=utf-8");
                // The SOAPAction header indicates which method you would like to invoke
                // and could be seen in the WSDL: <soap:operation soapAction="..." /> element
                client.Headers.Add("SOAPAction", "\"http://www.example.com/services/ISomeOperationContract/GetContract\"");
                var response = client.UploadString("http://example.com/service.svc", data);
                Console.WriteLine(response);
            }
        }
    }
