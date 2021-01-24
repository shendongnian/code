    using System;
    using Newtonsoft.Json;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string response = "{\"result\": {\"version\":1,\"Id\": 1, \"FirstName\": \"Bob\", \"LastName\": \"Jones\"},\"error\":null,\"id\":\"getperson\"}";
                var personDetails = RPCResponseParser.Parse<PersonDetails>(response);
    
                Console.WriteLine(personDetails.ToString());        
                Console.ReadLine();
            }
        }
    
        public static class RPCResponseParser
        {
            public static T Parse<T>(string json)
            {
                var response = JsonConvert.DeserializeObject<RPCResponse<T>>(json);
                return response.Result;
            }
        }
    
        public class RPCResponse<T>
        {
            public T Result { get; set; }
            public string Error { get; set; }
            public string Id { get; set; }
        }
        
        public class PersonDetails
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Version { get; set; }
    
            public override string ToString()
            {
                var str = "Id: " + this.Id + Environment.NewLine;
                str += "FirstName: " + this.FirstName + Environment.NewLine;
                str += "LastName: " + this.LastName + Environment.NewLine;
                str += "Version: " + this.Version + Environment.NewLine;
                return str;
            }
        }
    }
