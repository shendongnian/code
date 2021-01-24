    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; } = 0;
        public bool Validated { get; set; } = false;
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public Vehicle()
        {
        }
    }
