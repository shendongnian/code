    [XmlRoot("specialelement")]
    public class ExampleClass
    {
    	[XmlElement(ElementName = "value1")]
    	public string Value1 { get; set; }    
    	[XmlElement(ElementName = "value2")]
    	public string Value2 { get; set; }
    }
