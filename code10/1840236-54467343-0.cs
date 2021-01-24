    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    
    namespace SO54465235
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var wishList = new List<WishListItem>
                {
                    new Car { Price = 78000, Make = "Tesla", Model = "S", Name = "Tesla Model S" },
                    new Computer { Manufacturer = "Microsoft", Name = "Surface Pro 6", Price = 2000 },
                    new Platitude { Name = "World peace" }
                };
    
                KnownTypesBinder knownTypesBinder = new KnownTypesBinder
                {
                    KnownTypes = new List<Type> { typeof(Car), typeof(Computer), typeof(Platitude) }
                };
    
                string json = JsonConvert.SerializeObject(wishList, Formatting.Indented, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    SerializationBinder = knownTypesBinder
                });
    
                Console.WriteLine(json);
                Console.WriteLine();
    
                List<WishListItem> items = JsonConvert.DeserializeObject<List<WishListItem>>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Objects,
                    SerializationBinder = knownTypesBinder
                });
    
                foreach (var wishListItem in wishList)
                {
                    if (wishListItem is Platitude platitude)
                    {
                        Console.WriteLine($"{platitude.Name} is a hopeless dream");
                    }
                    else if (wishListItem is IPriceable priceThing)
                    {
                        Console.WriteLine($"At {priceThing.Price}, {priceThing.Name} is way out of my budget");
                    }
                    else
                    {
                        Console.WriteLine($"I want a {wishListItem.Name}");
                    }
                }
            }
        }
    
        public class KnownTypesBinder : ISerializationBinder
        {
            public IList<Type> KnownTypes { get; set; }
    
            public Type BindToType(string assemblyName, string typeName)
            {
                return KnownTypes.SingleOrDefault(t => t.Name == typeName);
            }
    
            public void BindToName(Type serializedType, out string assemblyName, out string typeName)
            {
                assemblyName = null;
                typeName = serializedType.Name;
            }
        }
    
        class WishListItem
        {
            public string Name { get; set; }
        }
    
        interface IPriceable
        {
            int Price { get; set; }
            string Name { get; set; }
        }
    
        class Car : WishListItem, IPriceable
        {
            public string Make { get; set; }
            public string Model { get; set; }
            public int Price { get; set; }
        }
    
        class Computer : WishListItem, IPriceable
        {
            public string Manufacturer { get; set; }
            public int Price { get; set; }
        }
    
        class Platitude : WishListItem
        {
    
        }
    }
