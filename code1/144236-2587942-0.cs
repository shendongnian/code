	[Serializable]
	public class Wrapper
	{
		[XmlElement(ElementName="Child1", Type=typeof(Child1)),
		XmlElement(ElementName="Child2", Type=typeof(Child2))]
		public Parent Value { get; set; }
	}
