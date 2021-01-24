    class RootObj
    {
        public List<Product> mitems { get; set; }
        public List<Product2> mitems2 { get; set; }
    }
    var Items = JsonConvert.DeserializeObject<RootObj>(json);
    foreach (var item in Items.mitems)
    {
        Console.WriteLine(item.Name);
    }
    foreach (var item2 in Items.mitems2)
    {
        Console.WriteLine(item2.Age);
    }
