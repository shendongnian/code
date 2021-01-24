    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
    }
    public class RootProduct
    {
        public List<Product> Products {get;set;}
    }
