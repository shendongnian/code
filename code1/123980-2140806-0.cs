    [Serializable] 
    [XmlType(Namespace = Constants.NS_A)] 
    [XmlRoot("Foo", Namespace = Constants.NS_A, IsNullable = false)]
    public class Foo  
    { 
      private Bar_ bar = new Bar_(); 
 
      [XmlElementAttribute("bar", Namespace = Constants.NS_B)] 
      public Bar_ Bar { get { return bar; }  
                        set { bar = value; } } 
 
    } 
 
