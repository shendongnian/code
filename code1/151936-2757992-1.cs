    string xml = @"<TestObject>
    					<FirstProperty>SomeValue</FirstProperty>
    					<SecondProperty>17</SecondProperty>
    				</TestObject>";
    XmlSerializer serializer = new XmlSerializer(typeof(TestObject));
    
    using (StringReader reader = new StringReader(xml))
    {
    	using (XmlTextReader xmlReader = new XmlTextReader(reader))
    	{
    		TestObject obj = serializer.Deserialize(xmlReader) as TestObject;
    	}
    }
