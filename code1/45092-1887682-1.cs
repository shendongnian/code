    using System.ComponentModel;
    using System.Xml.Serialization;
    
    public class Person
    {
        [DefaultValue(-1)]
        public int Age { get; set; }
        [XmlIgnore]
        public bool AgeSpecified { get { return Age >= 0; } }
    }
