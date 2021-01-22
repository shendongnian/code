    public class Quantity {
      // your attributes
      [XmlAttribute]
      public string foo;
    
      [XmlAttribute]
      public string bar;
    
      // and the element value (without a child element)
      [XmlText]
      public int qty;
    
    }
