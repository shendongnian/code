	public static void Main()
	{
		var r = new StringReader(@"TestPaySignService:
    Test:
        TestString:
            settings-key: TestStringValue
            types:
                - type1
                - type2
        TestString2:
            settings-key: TestStringValue2
            types:
                - type1
                - type2"); 
		var deserializer = new Deserializer();
		var yamlObject = deserializer.Deserialize<dynamic>(r)["TestPaySignService"]["Test"].Values;
		
        // just to print the json
		var serializer = new JsonSerializer();
		serializer.Serialize(Console.Out, yamlObject);
	}
