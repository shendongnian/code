    [XmlType("FullNames")]
    public class Names
    {
       [XmlAttribute("total")]
       public int Total {get;set;} 
       [XmlElement("Name")]
       public string[] Names{get;set;}
    }
