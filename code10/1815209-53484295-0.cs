    [XmlRoot("MyProgram")]//sepcifies the name of the root element
    public class MyProgram
    {
      [XmlAttribute("Version")]//name not required unless you want to change output to something different
       public string Version{get;set;}
       [XmlElement("ValueA")]//again, name not required if the name is the same
       public ValueA ValueA{get;set;}
       ....
    }
