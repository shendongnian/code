    public class Product
    {
        [DeserializeAs(Name = "id")]
        public int id { get; set; }
        [DeserializeAs(Name = "name")]
        public string name { get; set; }
    }
