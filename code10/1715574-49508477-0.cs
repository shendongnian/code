    static void Main(string[] args)
    {
        List<SecondClass> listOfSecondClasses = new List<SecondClass>();
        for (int i = 0; i < 10; ++i)
        {
    		listOfSecondClasses.Add(new SecondClass() { Name = "Bob" + i });
        }
    
        FirstClass firstClass = new FirstClass() { SecondClassArray = listOfSecondClasses.ToArray() };
    
        // Note that I am passing only the SecondClassArray, not the whole Element
        string xml = SerializeToXml(firstClass.SecondClassArray,"RealNames");
    
        Console.WriteLine(xml);
    
        Console.ReadLine();
    }
    
    public static string SerializeToXml<T>(T objectToSerialize, string RootNodeName)
    {
        if (objectToSerialize != null)
        {
    
    		XmlRootAttribute root = new XmlRootAttribute(RootNodeName);
    		XmlSerializer serializer = new XmlSerializer(typeof(T),root);
    
    		using (MemoryStream stream = new MemoryStream())
    		{
    			serializer.Serialize(stream, objectToSerialize, null);
    
    			string xmlString = "";
    			foreach (byte currentByte in stream.ToArray())
    			{
    		xmlString += (char)currentByte;
    			}
    
    			return xmlString;
    		}
        }
        return null;
    }
