	[XmlRoot("Bar")]
	public class Bar
	{
		[XmlAnyElement("Baz")]
		public XmlElement Baz { get; set; }
	}
	
