    // Serialize array - in you case it the stream you read from file.xml
    var ints = new[] { 1, 2, 3 };
    var arraySerializer = new XmlSerializer(typeof(int[]));
    var memoryStream = new MemoryStream(); // File.OpenWrite("file.xml")
    arraySerializer.Serialize(new StreamWriter(memoryStream), ints);
    
    // Save the closing node
    int sizeOfClosingNode = 13; // In this case: </ArrayOfInt> 
                                // Change the size to fit your array
    memoryStream.Position = memoryStream.Length - sizeOfClosingNode;
    var buffer = new byte[sizeOfClosingNode];
    memoryStream.Read(buffer, 0, sizeOfClosingNode);
    memoryStream.Position = memoryStream.Length - sizeOfClosingNode;
    
    // Add to serialized array an item
    var itemBuilder = new StringBuilder();
    new XmlSerializer(typeof(int)).Serialize(new StringWriter(itemBuilder), 4);
    XElement newXmlItem = XElement.Parse(itemBuilder.ToString());
    byte[] bytes = Encoding.Default.GetBytes(newXmlItem.ToString());
    memoryStream.Write(bytes, 0, bytes.Length);
    memoryStream.Write(buffer, 0, sizeOfClosingNode);
    
    // Example that it works
    memoryStream.Position = 0;
    var modifiedArray = (int[]) arraySerializer.Deserialize(memoryStream);
    CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, modifiedArray);
