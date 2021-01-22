	public class ArsAction
	{
		[XmlArray]
		[XmlArrayItem(ElementName="Component")]
		public List<string> Components { get; set; }
	}
