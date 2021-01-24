    string[] foo = { "Bar", "Baz", "Ban" };
    XmlSerializer serializer = new XmlSerializer(typeof(string[]));
    string file = "File.xml";
    using (StreamWriter sw = new StreamWriter(file))
    {
    	serializer.Serialize(sw,foo);
    }
    using (StreamReader sr = new StreamReader(file))
    {
    	//serializer = new XmlSerializer(typeof(string));  //Uncomment me to see your error message
    	var test = serializer.Deserialize(sr);
    	Console.WriteLine(test.ToString());
    }
