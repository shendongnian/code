    [XmlRoot("feed")]
    public class SerializedFeed
    {
    	[XmlArray("products")]
    	[XmlArrayItem("product")]
    	public List<Product> products { get; set; }
    }
    
    public class Product {
    	[XmlAttribute("name")]
    	public string Name {get; set;}
    }
