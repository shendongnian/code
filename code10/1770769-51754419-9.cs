    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public Distributor distributor { get; set; }
    }
    public class Distributor
    {
       
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
    }
