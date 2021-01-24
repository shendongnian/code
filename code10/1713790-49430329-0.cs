    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Enter product: ");
            var product = Console.ReadLine().ToLower();
            Console.Write("Enter town: ");
            var town = Console.ReadLine().ToLower();
            Console.Write("Enter quantity: ");
            var quantity = double.Parse(Console.ReadLine());
            var mapperData = new List<Mapper>()
                             {
                                 new Mapper { TownName = "Town1", ProductInfo = "Milk", Quantity = 1.50 },
                                 new Mapper { TownName = "Town1", ProductInfo = "Water", Quantity = 0.80 },
                                 new Mapper { TownName = "Town1", ProductInfo = "Whiskey", Quantity = 4.20 },
                                 new Mapper { TownName = "Town1", ProductInfo = "Peanuts", Quantity = 0.90 },
                                 new Mapper { TownName = "Town1", ProductInfo = "Chocolate", Quantity = 2.60 },
                                 new Mapper { TownName = "Town2", ProductInfo = "Milk", Quantity = 1.40 },
                                 new Mapper { TownName = "Town2", ProductInfo = "Water", Quantity = 0.70 },
                                 new Mapper { TownName = "Town2", ProductInfo = "Whiskey", Quantity = 3.90 },
                                 new Mapper { TownName = "Town2", ProductInfo = "Peanuts", Quantity = 0.70 },
                                 new Mapper { TownName = "Town2", ProductInfo = "Chocolate", Quantity = 1.50 },
                                 new Mapper { TownName = "Town3", ProductInfo = "Milk", Quantity = 1.90 },
                                 new Mapper { TownName = "Town3", ProductInfo = "Water", Quantity = 1.50 },
                                 new Mapper { TownName = "Town3", ProductInfo = "Whiskey", Quantity = 5.10 },
                                 new Mapper { TownName = "Town3", ProductInfo = "Peanuts", Quantity = 1.35 },
                                 new Mapper { TownName = "Town3", ProductInfo = "Chocolate", Quantity = 3.10 },
                             };
            var matchingQuantity = mapperData.FirstOrDefault(i => i.TownName.ToString().ToLower() == town.ToLower().Trim()
                                                      && i.ProductInfo.ToString().ToLower() == product.ToLower().Trim()).Quantity;
            Console.WriteLine(matchingQuantity * quantity);
        }
    }
    public class Mapper
    {
        public string TownName { get; set; }
        public string ProductInfo { get; set; }
        public double Quantity { get; set; }
    }
