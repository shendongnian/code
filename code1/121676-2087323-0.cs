    [XmlRoot("Car")]
    public class Car
    {
         public Car() 
         {
         }
    
         [XmlElement("Number")]
         public int Number { get; set; }
         [XmlElement("Color")]
         public int Color { get; set; }
         [XmlElement("Type")]
         public int Type { get; set; }
    }
