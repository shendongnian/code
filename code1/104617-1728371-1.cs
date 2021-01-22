    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new WebClient())
            {
                var data = File.ReadAllText("request.xml");
                client.Headers.Add("Content-Type", "text/xml;charset=utf-8");
                client.Headers.Add("SOAPAction", "\"http://www.example.com/services/ISomeOperationContract/GetContract\"");
                var response = client.UploadString("http://example.com/service.svc", data);
                Console.WriteLine(response);
            }
        }
    }
