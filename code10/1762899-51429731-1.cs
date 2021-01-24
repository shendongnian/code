	// You can convert the JSON to an instance of MyClass like this
	public MyClass ConvertJsonToMyClass(string json)
	{
		return JsonConvert.DeserializeObject<MyClass>(json);
	}
    // You can also convert an instance of MyClass to JSON like this
    public string ConvertMyClassToJson(MyClass obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
	
	// You can also serialize your object to XML
	public MyClass ConvertMyClassToXML(MyClass obj)
	{
		System.IO.StringWriter stringWriter = new System.IO.StringWriter();
		XmlSerializer serializer = new XmlSerializer(obj.GetType());
		serializer.Serialize(stringWriter, obj);
		return stringWriter.ToString();
	}
