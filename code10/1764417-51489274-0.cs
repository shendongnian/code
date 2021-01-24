      using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var json =
                    "{\"JrPwbApfIHbQhCUmVIoiVJcPYv93\":{\"address\":\"Jessore\",\"name\":\"Dev\"}," +
                    "\"iBRZAyn8TQTOgKTcByGOvJjL9ZB3\":{\"address\":\"Bogra\",\"name\":\"Kumar Saikat\"}}";
    
    
                var o = JsonConvert.DeserializeObject(json);
    
                var items = new List<Item>();
    
                foreach (dynamic x in o as IEnumerable)
                {
                    var i = new Item();
                    var y = x.First;
                    i.Name = y.name.Value;
                    i.Address = y.address.Value;
                    items.Add(i);
                }
            }
    
            public class Item
            {
                public string Name { get; set; }
                public string Address { get; set; }
            }
        }
    }
