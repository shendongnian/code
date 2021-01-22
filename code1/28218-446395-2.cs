    string file = Path.GetTempFileName(); // pretend this is a real file
    string tmpFile = Path.GetTempFileName();
    using (var stream = File.Create(tmpFile))
    using (var writer = XmlWriter.Create(stream))
    {
        writer.WriteStartElement("root");
        for (int i = 0; i < 100; i++)
        {
            writer.WriteElementString("test", null, 
                "All work and no play makes Jack a dull boy");
        }
        writer.WriteEndElement();
    }                
    File.Delete(file);
    File.Move(tmpFile,file);
