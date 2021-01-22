	private void DeserializeObject(string filename)
	{   
	   Console.WriteLine("Reading with XmlReader");
	
	   // Create an instance of the XmlSerializer specifying type and namespace.
	   XmlSerializer serializer = new 
	   XmlSerializer(typeof(OrderedItem));
	
	   // A FileStream is needed to read the XML document.
	   FileStream fs = new FileStream(filename, FileMode.Open);
	   XmlReader reader = new XmlTextReader(fs);
	       
	   // Declare an object variable of the type to be deserialized.
	   OrderedItem i;
	
	   // Use the Deserialize method to restore the object's state.
	   i = (OrderedItem) serializer.Deserialize(reader);
	
	   // Write out the properties of the object.
	   Console.Write(
	   i.ItemName + "\t" +
	   i.Description + "\t" +
	   i.UnitPrice + "\t" +
	   i.Quantity + "\t" +
	   i.LineTotal);
	}
