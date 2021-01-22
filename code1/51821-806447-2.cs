    XDocument doc = new XDocument();
    using (var writer = doc.CreateWriter())
    {
        // write xml into the writer
        var serializer = new DataContractSerializer(objectToSerialize.GetType());
        serializer.WriteObject(writer, objectToSerialize);
    }
    Console.WriteLine(doc.ToString());
