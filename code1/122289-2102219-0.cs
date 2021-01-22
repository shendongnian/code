    public class A<T>
    {
         [XmlAttribute("Name")]
         public string Name {get; set;}
    
         [XmlElement(typeof(T))]
         public List<T> Items { get; set; }
    
    }
