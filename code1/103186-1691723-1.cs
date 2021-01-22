    // Serialize array - in you case it the stream you read from file.xml
    var ints = new[] { 1, 2, 3 };
    var arraySerializer = new XmlSerializer(typeof(int[]));
    var memoryStream = new MemoryStream(); // File.OpenWrite("file.xml")
    arraySerializer.Serialize(new StreamWriter(memoryStream), ints);
    
    // Save the closing node
    int sizeOfClosingNode = 13; // In this case: "</ArrayOfInt>".Length
                                // Change the size to fit your array
                                // e.g. ("</ArrayOfOtherType>".Length)
    // Set the location just before the closing tag
    memoryStream.Position = memoryStream.Length - sizeOfClosingNode;
    // Store the closing tag bytes
    var buffer = new byte[sizeOfClosingNode];
    memoryStream.Read(buffer, 0, sizeOfClosingNode);
    // Set back to location just before the closing tag.
    // In this location the new item will be written.
    memoryStream.Position = memoryStream.Length - sizeOfClosingNode;
    
    // Add to serialized array an item
    var itemBuilder = new StringBuilder();
    // Write the serialized item as string to itemBuilder
    new XmlSerializer(typeof(int)).Serialize(new StringWriter(itemBuilder), 4);
    // Get the serialized item XML element (strip the XML document declaration)
    XElement newXmlItem = XElement.Parse(itemBuilder.ToString());
    // Convert the XML to bytes can be written to the file
    byte[] bytes = Encoding.Default.GetBytes(newXmlItem.ToString());
    // Write new item to file.
    memoryStream.Write(bytes, 0, bytes.Length);
    // Write the closing tag.
    memoryStream.Write(buffer, 0, sizeOfClosingNode);
    
    // Example that it works
    memoryStream.Position = 0;
    var modifiedArray = (int[]) arraySerializer.Deserialize(memoryStream);
    CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, modifiedArray);
