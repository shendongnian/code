    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public ICollection<Rental> Rentals { get; set; }
    }
