	[XmlRoot(ElementName="fund")]
	public class Fund 
	{
		[XmlElement(ElementName="name")]
		public string Name { get; set; }
	
		[XmlElement(ElementName="indexName")]
		public string IndexName { get; set; }
	
		[XmlAttribute(AttributeName="yclass")]
		public string Yclass { get; set; }
	}
	
	[XmlRoot(ElementName="instance")]
	[XmlType(Namespace = "")] // Add this
	public class Instance 
	{
		[XmlElement(ElementName="language")]
		public Language Language { get; set; }
	
		[XmlElement(ElementName="threshold")]
		public string Threshold { get; set; }
	
		[XmlElement(ElementName="typePeriod")]
		public string TypePeriod { get; set; }
	
		[XmlElement(ElementName="interval")]
		public string Interval { get; set; }
	
		[XmlElement(ElementName="valuePeriod")]
		public string ValuePeriod { get; set; }
	
		[XmlElement(ElementName="fund")]
		public Fund Fund { get; set; }
	
		[XmlAttribute(AttributeName="yclass")]
		public string Yclass { get; set; }
	
		[XmlAttribute(AttributeName="yid")]
		public string Yid { get; set; }
	}
	
	[XmlRoot(ElementName="datas", Namespace="http://www.blahblah.com/engine/42")]
	public class Datas
	{
		[XmlElement(ElementName="instance", Namespace="http://www.blahblah.com/engine/42")]
		public Instance Instance { get; set; }
	}
	
	[XmlRoot(ElementName="input", Namespace="http://www.blahblah.com/engine/42")]
	public class Input
	{
		[XmlElement(ElementName="datas", Namespace="http://www.blahblah.com/engine/42")]
		public Datas Datas { get; set; }
	
		//Remove This
		//[XmlAttribute(AttributeName="y", Namespace="http://www.blahblah.com/engine/42", Form = XmlSchemaForm.Qualified)]
		//public string Y { get; set; }
	}
	// Add this
	[XmlRoot(ElementName="language")]
	public class Language 
	{
		[XmlAttribute(AttributeName="yid")]
		public string Yid { get; set; }
	}
