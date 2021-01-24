    using Newtonsoft.Json;
    
    class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
    
        public Person(int Id)
        {
            // here would be an RPC call to get the FirstName,LastName,Version. result is JSON    
            string response = "{\"result\": {\"version\":1,\"Id\": 1, \"FirstName\": \"Bob\", \"LastName\": \"Jones\"},\"error\":null,\"id\":\"getperson\"}";             
            var o = JsonConvert.DeserializeObject<RPCResponse<PersonDetails>>(response).result;
            this.Id = Id;
            FirstName = o.FirstName;
            LastName = o.LastName;
            Version = o.Version;
        }
    
        private class PersonDetails
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Version { get; set; }
        }
    }
    
    public class RPCResponse<T>
    {
        public T result { get; set; }
        public string error { get; set; }
        public string id { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person(1);
            var f = p.FirstName;
            // p.FirstName should be Bob but is null
        }
    }
