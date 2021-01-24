    class RootObj
    {
        public List<Product> mitems { get; set; }
        public List<Product2> mitems2 { get; set; }
    }
    var Items = JsonConvert.DeserializeObject<RootObj>(json);
