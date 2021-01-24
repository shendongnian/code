    [Table("Pizzas")]
    public class Pizza
    {
        [Key]
        public int id { get; set; }
    
        public string Flavour { get; set; }
        public DateTime Date { get; set; }
        public string Size { get; set; }
        public Deliveryman Deliveryman { get; set; }
    }
