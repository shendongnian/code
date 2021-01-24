    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Phones { get; set; }
        public string[] Cars { get; set; }
        
        [BsonIgnore]
        public string DisplayPhones => string.Join(", ", Phones);
        
        [BsonIgnore]
        public string DisplayCars => string.Join(", ", Cars);
    }
