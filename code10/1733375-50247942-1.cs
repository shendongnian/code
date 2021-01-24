	public class MyClass
	{
		[XmlElement(ElementName = "Test")]
		public string MyProperty { get; set; }
	}
    new MyClass().GetXmlElementName(x => x.MyProperty) // output "Test"
