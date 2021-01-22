    [XmlType("enquiry")]
    [XmlRoot("enquiry")]
    public class Enquiry
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
    
        [XmlElement("enquiry_no")]
        public int EnquiryNumber { get; set; }
    
        [XmlArray("vehicles")]
        [XmlArrayItem("Vehicle", typeof(Vehicle))]
        public List<Vehicle> Vehicles
        {
            get { return this.vehicles; }
            set { this.vehicles = value ?? new List<Vehicle>(); }
        }
    
        [XmlAnyElement]
        public XmlElement[] AnyElements;
        [XmlAnyAttribute]
        public XmlAttribute[] AnyAttributes;
    }
    
    public class Vehicle
    {
        [XmlElement("vehicle_type")]
        public string VehicleType { get; set; }
        [XmlElement("vehicle_make")]
        public string VehicleMake { get; set; }
        [XmlElement("vehicle_model")]
        public string VehicleModel { get; set; }
    }
