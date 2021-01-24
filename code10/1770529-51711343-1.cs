    public class Deliveryman
    {
        [Key]
        public int Id { get; set; }
    
        public string Name { get; set; }
        public string Cellphone { get; set; }
        public string Car { get; set; }
        public ICollection<Pizza> Pizzas {get; set;}
    }
