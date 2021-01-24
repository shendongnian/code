    public class VehicleTypeDTO
    {
        public int Id{ get; set; }
        public string Name{ get; set; }
    }
    
    public class LicenseDTO
    {
        public int Id { get; set; }
        public List<VehicleTypeDTO> VehicleTypes { get; set; }
    }
