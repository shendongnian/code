	[XmlRoot(ElementName = "min")]
	public class Min
	{
		[XmlAttribute(AttributeName = "missing")]
		public string Missing { get; set; }
		[XmlText]
		public string Value { get; set; }
	}
	
	[XmlRoot(ElementName = "max")]
	public class Max
	{
		[XmlAttribute(AttributeName = "missing")]
		public string Missing { get; set; }
		[XmlText]
		public string Value { get; set; }
	}
	[XmlRoot(ElementName = "source_code")]
	public class Source_code
	{
		[XmlAttribute(AttributeName = "missing")]
		public string Missing { get; set; }
		[XmlText]
		public string Value { get; set; }
	}
	[XmlRoot(ElementName = "COMPO")]
	public class COMPO
	{
		[XmlElement(ElementName = "alim_code")]
		public string Alim_code { get; set; }
		[XmlElement(ElementName = "const_code")]
		public string Const_code { get; set; }
		[XmlElement(ElementName = "teneur")]
		public string Teneur { get; set; }
		[XmlElement(ElementName = "min")]
		public Min Min { get; set; }
		[XmlElement(ElementName = "max")]
		public Max Max { get; set; }
		[XmlElement(ElementName = "code_confiance")]
		public string Code_confiance { get; set; }
		[XmlElement(ElementName = "source_code")]
		public Source_code Source_code { get; set; }
	}
	[XmlRoot(ElementName = "TABLE")]
	public class TABLE
	{
		[XmlElement(ElementName = "COMPO")]
		public List<COMPO> COMPO { get; set; }
	}
	private void ReadCompoWithSerializer()
	{
		string xmlFile = "test.xml";
		string xml = File.ReadAllText(xmlFile);
		XmlSerializer serializer = new XmlSerializer(typeof(TABLE));
		TABLE table = null;
		using (var reader = new StringReader(xml))
		{
			table = (TABLE)serializer.Deserialize(reader);
		}
	}
