    using System;
    using Newtonsoft.Json.Linq;
    
    class Program
    {
        public static void Main()        
        {
            string json = @"{
                'result': 'true',
                'available': {
                    'BTC': '0.83337671',
                    'LTC': '94.364',
                    'ETH': '0.07161',
                    'ETC': '82.35029899'
                },
                'locked': {
                    'BTC': '0.0002',
                    'YAC': '10.01'
                }
            }".Replace('\'', '"');
            JObject root = JObject.Parse(json);
            JObject coins = (JObject) root["available"];
            foreach (JProperty property in coins.Properties())
            {
                string name = property.Name;
                string value = (string) property.Value;
                Console.WriteLine($"Name: {name}; Value: {value}");
            }    
        }
    }
