    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace ConsoleApp1
    {
        class Program
        {
            public class Item
            {
                [JsonProperty("_id")]
                public string Guid { get; set; }
    
                [JsonProperty(PropertyName = "company")]
                public string Company { get; set; }
    
                [JsonProperty(PropertyName = "id")]
                public string Id { get; set; }
    
                [JsonProperty(PropertyName = "parent")]
                public string Parent { get; set; }
    
                [JsonProperty(PropertyName = "children")]
                public List<Item> Children { get; set; }
            }
    
    
            private static string jsonString = "[{\"_id\":\"5c04fc163838b0772dd9636d\",\"Company\":\"TESTCOMPANY\",\"id\":\"test_uk\",\"parent\":\"\"},{\"_id\":\"5c05181f0ab89a44a969015d\",\"Company\":\"TESTCOMPANY\",\"id\":\"Gateway\",\"parent\":\"test_uk\"},{\"_id\":\"5c0518723838b0772dd9678e\",\"Company\":\"TESTCOMPANY\",\"id\":\"Device1\",\"parent\":\"Gateway\"},{\"_id\":\"5c0518723838b077789636e\",\"Company\":\"TESTCOMPANY\",\"id\":\"Device2\",\"parent\":\"Gateway\"},{\"_id\":\"5c0518723838b0772dd9636e34\",\"Company\":\"TESTCOMPANY\",\"id\":\"Adapter\",\"parent\":\"test_uk\"},{\"_id\":\"5c0518723838b0772dd9636e\",\"Company\":\"TESTCOMPANY\",\"id\":\"AdapterDevice\",\"parent\":\"Adapter\"},{\"_id\":\"5c04fc163838b0772dd93454d\",\"Company\":\"TESTCOMPANY\",\"id\":\"test_us\",\"parent\":\"\"},{\"_id\":\"5c0518723838b0772dd9636e\",\"Company\":\"TESTCOMPANY\",\"id\":\"Device\",\"parent\":\"test_us\"}]";
    
            static void Main(string[] args)
            {
                var items =  JsonConvert.DeserializeObject<List<Item>>(jsonString);
    
                var dictionary = new Dictionary<string, Item>();
    
                foreach (var item in items)
                {
                    if (!dictionary.ContainsKey(item.Parent))
                    {   
                        dictionary.Add(item.Id, item);
                    }
                    else
                    {
                        if (dictionary[item.Parent].Children == null)
                            dictionary[item.Parent].Children = new List<Item>();
                        dictionary[item.Parent].Children.Add(item);
                    }
                }
    
                string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
    
                System.Console.WriteLine(json);
    
                System.Console.ReadLine();
            }
        }
    }
