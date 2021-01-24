    [XmlRoot(ElementName="CategoryMapping", Namespace="urn:ebay:apis:eBLBaseComponents")]
	public class CategoryMapping {
		[XmlAttribute(AttributeName="id")]
		public string Id { get; set; }
		[XmlAttribute(AttributeName="oldID")]
		public string OldID { get; set; }
	}
	[XmlRoot(ElementName="GetCategoryMappingsResponse", Namespace="urn:ebay:apis:eBLBaseComponents")]
	public class GetCategoryMappingsResponse {
		
		
		[XmlElement(ElementName="Version", Namespace="urn:ebay:apis:eBLBaseComponents")]
		public string Version { get; set; }		
		[XmlElement(ElementName="CategoryMapping", Namespace="urn:ebay:apis:eBLBaseComponents")]
		public List<CategoryMapping> CategoryMapping { get; set; }
		
	}
