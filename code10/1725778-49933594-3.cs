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
    
                //If you want to access using strong type.
                var response = JsonConvert.DeserializeObject<Response>(jsonString);
                var secondSymbol = response.Second.symbol.ToString();
                System.Console.WriteLine(secondSymbol);
    
                //If you want to access using dynamic type, will evalute in runtime.
                var responseDynamic = JsonConvert.DeserializeObject<dynamic>(jsonString);
                var secondSymbolDynamic = responseDynamic.Second.symbol.ToString() ;
                System.Console.WriteLine(secondSymbolDynamic);
    
                System.Console.ReadLine();
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
