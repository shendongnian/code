    using System;
    using Newtonsoft.Json;
    
    namespace JsonPrettyPrint
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Product product = new Product
                    {
                        Name = "Apple",
                        Expiry = new DateTime(2008, 12, 28),
                        Price = 3.99M,
                        Sizes = new[] { "Small", "Medium", "Large" }
                    };
    
                string json = JsonConvert.SerializeObject(product, Formatting.Indented);
                Console.WriteLine(json);
   
                Product deserializedProduct = JsonConvert.DeserializeObject<Product>(json);
            }
        }
    
        internal class Product
        {
            public String[] Sizes { get; set; }
            public decimal Price { get; set; }
            public DateTime Expiry { get; set; }
            public string Name { get; set; }
        }
    }
