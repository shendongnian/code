    [XmlRoot(ElementName="Property")]
    public class Property 
    {
       [XmlElement(ElementName="Name")]
       public string Name { get; set; }
       [XmlElement(ElementName="Value")]
       public string Value { get; set; }
    }
    
    [XmlRoot(ElementName="Properties")]
    public class Properties 
    {
        [XmlElement(ElementName="Property")]
    	public List<Property> Property { get; set; }
    }
    
    [XmlRoot(ElementName="Object")]
    public class Object 
    {
       [XmlElement(ElementName="Properties")]
       public Properties Properties { get; set; }
    }
    
    [XmlRoot(ElementName="ArrayOfObject")]
    public class GetTaskListResponse 
    {
       [XmlElement(ElementName="Object")]
       public List<Object> Object { get; set; }
    }
