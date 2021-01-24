    using RestSharp;
    using RestSharp.Deserializers;
    using System;
    using System.Text;
    namespace ConsoleApp3
    {
        internal class Program
        {
            private static RestClient client = new RestClient("https://euterpe.webuntis.com/WebUntis/jsonrpc.do?school=HTL-Perg");
            public class AuthenticationResponse
            {
                [DeserializeAs(Name = "id")]
                public string id { get; set; }
                [DeserializeAs(Name = "result", Content = true)]
                public AuthenticationResult result { get; set; }
            }
            public class AuthenticationResult
            {
                [DeserializeAs(Name = "sessionId")]
                public string sessionId { get; set; }
                [DeserializeAs(Name = "personType")]
                public int personType { get; set; }
                [DeserializeAs(Name = "personId")]
                public int personId { get; set; }
                [DeserializeAs(Name = "klasseId")]
                public int klasseId { get; set; }
            }
            private static void Main(string[] args)
            {
                client.AddHandler(new JsonDeserializer(), "application/json-rpc");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-type", "application/json");
                request.AddJsonBody(new
                {
                    id = "ID",
                    method = "authenticate",
                    @params = new
                    {
                        user = "kung",
                        password = "foo",
                        client = "CLIENT"
                    },
                    jsonrpc = "2.0"
                });
                var response = client.Execute<AuthenticationResponse>(request);
                var resp = Encoding.UTF8.GetString(response.RawBytes, 0, (int)response.ContentLength);
                Console.WriteLine(response.Data);
            }
        }
    }
