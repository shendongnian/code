    [XmlRoot("Car")] 
    public class Car 
    { 
        public Car()  
        { 
        } 
 
        [XmlElement("Registration")] 
        public string RegNo { get; set; }
        [XmlElement("Make")]
        public string Make { get; set; }
        [XmlElement("Model")]
        public string Model { get; set; }
    }
