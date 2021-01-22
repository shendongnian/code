    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class FavoriteSettings
    {
        [XmlArray("Customer")]
        [XmlArrayItem("ID")]
        public List<int> Customers { get; set; }
    
        [XmlArray("Supplier")]
        [XmlArrayItem("ID")]
        public List<int> Suppliers { get; set; }
    }
