    public class Shop
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
    var dictionary = new Dictionary<string, Shop>();
    dictionary["En"] = new Shop { Name = "Shop", Path = "/en" };
    dictionary["De"] = new Shop { Name = "Geschäft", Path = "/de" };
