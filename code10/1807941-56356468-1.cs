    public class Dealer
    {
       [Key]
       public Guid Id { get; set; }
       public string Name { get; set; }
       [NotMapped]
       public List<Car> OldCars { get; set; } => NewCars.Where(c => c.IsOld == true);
       public List<Car> NewCars { get; set; } = new List<Car>();
    }
    
    public class Car
    {
       [Key]
       public Guid Id { get; set; }
       public string Model { get; set; }
       public Dealer Dealer { get; set; }
       public bool IsOld { get; set; }
    }
