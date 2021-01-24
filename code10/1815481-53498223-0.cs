    [XmlRoot(Namespace = "urn:ebay:apis:eBLBaseComponents")] //<-- here
    public class GetCategoryMappingsResponse
    {
    	[System.Xml.Serialization.XmlElement("CategoryMapping")]
    	public List<CategoryMapping> CategoryMapping { get; set; }
    	public string CategoryVersion { get; set; }
    }
