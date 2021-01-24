    [System.SerializableAttribute()]
    [ComplexType]                       // <-- See addition here
    public class Distributors
    {
        [System.Xml.Serialization.XmlElementAttribute("Distributor", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Distributor> Distributor { get; set; }
        // navigation property used to define the many-to-many relationship
        public virtual List<Product> Products { get; set; }
    }
    [System.SerializableAttribute()]
    [ComplexType]                       // <-- and here
    public class Country_Markets
    {
        [System.Xml.Serialization.XmlElementAttribute("Country_Market", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Country_Market> Country_Market { get; set; }
        // navigation property used to define the many-to-many relationship
        public virtual List<Product> Products { get; set; }
    }
