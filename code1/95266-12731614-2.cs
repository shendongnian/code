    XDocument xmlDoc = new XDocument(
            new XDeclaration("1.0", "utf-8", "no"), 
            new XElement("foo", "bar"));
    MemoryStream memstream = new MemoryStream();
    XmlTextWriter xmlwriter = new XmlTextWriter(memstream, new UTF8Encoding());
    //'Write' (save) XDocument XML to MemoryStream-backed XmlTextWriter instance
    xmlDoc.Save(xmlwriter);
    //Read back XML string from stream
    xmlwriter.Flush();    
    memstream.Seek(0, SeekOrigin.Begin);  //OR "stream.Position = 0"
    StreamReader streamreader = new StreamReader(memstream);
    string xml = streamreader.ReadToEnd();
    Console.WriteLine(xml);
    Console.WriteLine(reader.ReadToEnd());
