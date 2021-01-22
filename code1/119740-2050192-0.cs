	public class Category
	{		
		[XmlAttribute]
		public string Attrib1 { get; set; }
	
		[XmlAttribute]
		public string Attrib2 { get; set; }		
		
		[XmlElement("Item")]
		public List<string> Items { get; set; }
	}
