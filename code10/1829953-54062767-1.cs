    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = "{\"result\": {\"version\":1,\"Id\": 1, \"FirstName\": \"Bob\", \"LastName\": \"Jones\"},\"error\":null,\"id\":\"getperson\"}";
                var personDetails = new PersonDetails(json);
                
                Console.WriteLine(personDetails.ToString());        
                Console.ReadLine();
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
    
            public PersonDetails() {}
    
            public PersonDetails(string json)
            {
                var result = JsonConvert.DeserializeObject<RPCResponse<PersonDetails>>(json).Result;
    
                foreach (var prop in typeof(PersonDetails).GetProperties())
                {
                    var value = prop.GetValue(result);
                    prop.SetValue(this, value);
                }
            }
    
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
