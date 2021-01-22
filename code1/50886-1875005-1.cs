    // Convert the DetachedCriteria to a byte array
    MemoryStream ms = new MemoryStream();
    IFormatter formatter = new BinaryFormatter();
    formatter.Serialize(ms, detachedCriteria);
    
    // Serialize the byte array
    XmlSerializer s = new XmlSerializer(typeof(byte[]));
    TextWriter writer = new StringWriter();
    s.Serialize(writer, ms.Buffer);
    writer.Close();
