    namespace project.Models    
    {
        public class Product
        {
            [Key]
            public int product_id { get; set; }
            public ICollection<Distributor> Distributors { get; set; }
            public ICollection<Country_Market> Country_Markets { get; set; }
        }
        public class Distributor
        {    
            [Key]
            public int ID { get; set; }
            public string name { get; set; }
        }
        public class Country_Market
        {
            [Key]
            public int ID { get; set; }
            public string shortcode { get; set; }
        }
    }
