    var rc = new RecordExample()
    {
        TheDate = DateTime.Today,
        TheTime = DateTime.UtcNow
    };
    
    var serializer = new XmlSerializer(typeof(RecordExample));
    
    var ms = new MemoryStream();
    
    serializer.Serialize(ms, rc);
    
    ms.Seek(0, SeekOrigin.Begin);
    
    Console.WriteLine(new StreamReader(ms).ReadToEnd());
