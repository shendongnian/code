    public class Driver
    {
        public int DriverID { get; set; }
        public string Name { get; set; }
        //other additional fields
    
        public virtual DriverCar DriverCar { get; set; }
    }
    
    public class Car
    {
        public int CarID { get; set; }
        public string Brand { get; set; }
        //other additional fields
    
        public virtual DriverCar DriverCar { get; set; }
    }
    
    public class DriverCar
    {
        public int DriverCarID { get; set; }
    
        public int DriverID { get; set; }
        public virtual Driver Driver { get; set; }
    
        public int CarID { get; set; }
        public virtual Car Car { get; set; }
     }
    modelBuilder.Entity<DriverCar>()
                            .HasForeignKey(k => k.DriverId)
                            .HasRequired(a => a.Driver)
                            .WithOptional(s => s.DriverCar)
                            .WillCascadeOnDelete(false);
    
    modelBuilder.Entity<DriverCar>()
                            .HasForeignKey(k => k.CarId)
                            .HasRequired(a => a.Car)
                            .WithOptional(s => s.DriverCar)
                            .WillCascadeOnDelete(false);
