    [SoapDocumentMethod(ResponseElementName = "EncodingTestResponse", ResponseNamespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [return: XmlArray("item", Namespace = "", IsNullable = false)]
    [SoapTrace]
    public item[] EncodingTest()
    {
    	object[] result = this.Invoke("EncodingTest", new object[] { });
    	return (item[])result[0];
    }
    [SoapType(TypeName = "Map", Namespace = "http://xml.apache.org/xml-soap")]
    	public class item
    	{
    		[XmlElement(Form = XmlSchemaForm.Unqualified)]
    		public string key { get; set; }
    
    		[XmlElement(Form = XmlSchemaForm.Unqualified)]
    		public string value { get; set; }
    
    		public item[] items { get; set; }
    	}
