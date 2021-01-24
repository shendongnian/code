    namespace StackOverflow
    {
        internal class Item
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public long Price { get; set; }
        }
    
        internal class Car: Item
        {
            internal Car(string brand, string model, long price)
            {
                Brand = brand;
                Model = model;
                Price = price;
            }
        }
    
        internal class Plane : Item
        {
            internal Plane(string brand, string model, long price)
            {
                Brand = brand;
                Model = model;
                Price = price;
            }
        }
    }
    
     internal class Company
        {
            public string Brand { get; set; }
            public string Country { get; set; }
    
            internal Company(string brand, string country)
            {
                Brand = brand;
                Country = country;
            }
        }
    
    
      internal class InventoryItem
        {
            public InventoryItem(Item item, int count)
            {
                Item = item;
                Count = count;
            }
    
            public Item Item { get; set; }
            public int Count { get; set; }
        }
    
     internal class Program
        {
            static void Main(string[] args)
            {
                 IReadOnlyList<InventoryItem> vehicles = new List<InventoryItem>
                    {
                    new InventoryItem(new Car("Ford", "Focus", 115000), 20),
                    new InventoryItem(new Car("BMW", "7 Series", 425000), 12),
                    new InventoryItem(new Car("Lexus", "ES", 300000), 5),
                    new InventoryItem(new Plane("Boeing", "747", 2200000000), 2),
                    new InventoryItem(new Car("Nissan", "Micra", 90000), 27),
                    new InventoryItem(new Plane("Airbus", "A380", 4150000000), 1)
                    };
    
                IReadOnlyList<Company> companies = new List<Company>
                {
                    new Company("Ford", "US"),
                    new Company("BMW", "Germany"),
                    new Company("Lexus", "Japan"),
                    new Company("Nissan", "Japan"),
                    new Company("Boeing", "US"),
                    new Company("Airbus", "France")
                };
    
                var countryCount = companies.Join(vehicles, i => i.Brand, j => j.Item.Brand, (i, j) => new { i.Country, j.Count }).GroupBy(k => k.Country).Select(group=> new { Country = group.Key, Total = group.Sum(count => count.Count) });
                foreach(var group in countryCount)
                {
                    Console.WriteLine($"Country : { group.Country}, count { group.Total }");
                }
                Console.ReadKey();
            }
        }
