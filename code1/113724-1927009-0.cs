    public class OptionView
    {
       private XmlElement XmlElement;
       public Element(XmlElement xmlElement)
       {
          XmlElement = xmlElement;
       }
       public string Name { get { return XmlElement.Name; } }
       public string Value 
       { 
          get { return XmlElement.InnerText; } 
          set { XmlElement.InnerText = value; }
       }
    }
