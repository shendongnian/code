    public class ShootingLocation : LocationBase
    {
        public int ShootingLocationID { get; set; }
        public ParkingLocation ParkingLocation { get; set; }
        // Navigation property
        public ICollection<Photo> Photos { get; set; }
    }
    public class Photo
    {
        public int PhotoID { get; set; }
        public string Description { get; set; }
        public byte[] ImageBytes { get; set; }
        // Navigation properties
        public int ShootingLocationID { get; set; }
        public ShootingLocation ShootingLocation { get; set; }
    }
