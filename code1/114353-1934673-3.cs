    using System.Xml.Serialization;
    
    [XmlRoot( "Andromeda" )]
    public class Andromeda
    {
       [XmlElement( "Damage" )]
       public String Damage
       {
          get;set;
       }
    
       [XmlElement( "Armor" )]
       public double Armor
       {
          get;set;
       }
    }
