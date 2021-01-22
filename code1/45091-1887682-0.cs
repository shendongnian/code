    using System.Xml.Serialization;
    
    public class Person
    {
        public bool? Employed { get; set; }
    
        [XmlIgnore]
        public bool EmployedSpecified { get { return Employed.HasValue; } }
    }
