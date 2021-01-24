    public static void Main()
    {
        StreamReader sr = new StreamReader(@"C:\Temp\Test.txt");
        List<Shop> shops = new List<Shop>();
        Shop shop = null;
        while(!sr.EndOfStream)
        {
            string line = sr.ReadLine().Trim().TrimEnd(';');
            string[] split = line.Split(';');
            if (split.Count() == 3)
            {
                if (shop != null)
                    shops.Add(shop);
                shop = new Shop()
                {
                    Name = split[0],
                    Adr = split[1],
                    TNumber = split[2],
                };
            }
            else
            {
                Item item = new Item()
                {
                    Name = split[0],
                    Price = split[1],
                    Color = split[2],
                    Weight = split[3],
                    Size = split[4],
                    Rating = split[5]
                };
                shop.Items.Add(item);
            }
        }
        if (shop != null)
            shops.Add(shop);
            
        foreach (Shop s in shops)
        {
            Console.WriteLine(s.Name + ", " + s.Adr + ", " + s.TNumber);
            foreach (Item i in s.Items)
            {
                Console.WriteLine("   " + i.Name + ", " + i.Price);
            }
        }
    }
    public class Shop
    {
        public Shop() { this.Items = new List<Item>(); }
        public string Name { get; set; }
        public string Adr { get; set; }
        public string TNumber { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Color { get; set; }
        public string Weight { get; set; }
        public string Size { get; set; }
        public string Rating { get; set; }
    }
