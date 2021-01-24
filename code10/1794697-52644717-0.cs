    public class appSettings
    {
    	[XmlElement("add")]
    	public List<Item> AddItems { get; set; }
    }
    
    public class Item
    {
    	[XmlAttribute("key")]
    	public string Key { get; set; }
    	[XmlAttribute("value")]
    	public string Value { get; set; }
    	[XmlAttribute(Namespace="http://schemas.microsoft.com/XML-Document-Transform")]
    	public string Transform { get; set; }
    	[XmlAttribute(Namespace="http://schemas.microsoft.com/XML-Document-Transform")]
    	public string Locator { get; set; }
    }
    
    XmlSerializer ser = new XmlSerializer(typeof(appSettings));
    var settings = (appSettings)ser.Deserialize(File.Open("test.xml", FileMode.Open));
    settings.AddItems; //<- there is your list
