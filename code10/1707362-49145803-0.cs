    public class Rootobject
    {
        public List<Product> product { get; set; }
    }
    public class Product
    {
        public _Id _id { get; set; }
        public string product_name { get; set; }
        public string supplier { get; set; }
        public int quantity { get; set; }
        public string unit_cost { get; set; }
    }
    public class _Id
    {
        [JsonProperty("$oid")]
        public string oid { get; set; }
    }
