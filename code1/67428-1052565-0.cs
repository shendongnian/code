    [XmlType("FullNames")]
    public class FullNames
    {
       [XmlAttribute("Id")]
       public int Id {get;set;}
       [XmlElement("Name")]
       public string[] Names{get;set;}
    }
