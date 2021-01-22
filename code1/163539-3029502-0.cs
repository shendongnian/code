    [System.Xml.Serialization.XmlRootAttribute("books", Namespace = "", IsNullable = false)]  
    public class BookCollection  
    {  
        [System.Xml.Serialization.XmlElement("books")]  
        public Book[] Books { get; set; }  
    }
