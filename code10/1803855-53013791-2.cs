    public class Driver
    {
        public int DriverID { get; set; }
        public string Name { get; set; }
        //other additional fields
    
        public DriverCar? DriverCar { get; set; }
    }
    
    public class Car
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        //other additional fields
    
        public DriverCar? DriverCar { get; set; }
    }
    
    public class DriverCar
    {
        public int DriverCarID { get; set; }
    
        [ForeignKey("Driver")]
        public int DriverID { get; set; }
        public Driver Driver { get; set; }
    
        [ForeignKey("Car")]
        public int CarID { get; set; }
        public Car Car { get; set; }
     }
    modelBuilder.Entity<Driver>()
                            .HasOptional(a => a.DriverCar)
                            .WithRequired(s => s.Driver)
                            .WillCascadeOnDelete(false);
    
    modelBuilder.Entity<Car>()
                            .HasOptional(a => a.DriverCar)
                            .WithRequired(s => s.Car)
                            .WillCascadeOnDelete(false);
    
