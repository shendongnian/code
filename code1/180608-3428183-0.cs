    public class Equipment
    { 
        public int Id { get; set; } 
        public Site Site { get; set; } 
        public DateTime Arrival { get; set; } 
        public DateTime Departure { get; set; } 
        public IList<EquipmentUtilization> EquipmentUtilizations { get; set; }
        public bool IsIdle
        {
            get
            {
                // This checks if the EquipmentUtilizations is empty
                // or if the Equipment is older than three days
                return (this.EquipmentUtilizations == null) ||
                       ((this.Departure == null) &&
                        (this.Arrival < DateTime.Today.AddDays(-3))
            }
        }
    }
