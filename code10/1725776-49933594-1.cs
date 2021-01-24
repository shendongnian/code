    using Newtonsoft.Json;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var jsonString = @"{
                                'First': {
                                    'name': 'One',
                                    'symbol': '1st'
                                },
                                'Second': {
                                    'name': 'Two',
                                    'symbol': '2nd'
                                }
                            }";
    
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
    
            }
    
            public class Response
            {
                public Item First { get; set; }
                public Item Second { get; set; }
            }
    
            public class Item
            {
                public string name { get; set; }
                public string symbol { get; set; }
            }
        }
    }
