    const String fileName = "test.file";
    const String header = "MyHeader";
    
    var headerBytes = Encoding.ASCII.GetBytes(header);
    var fileContent = File.ReadAllBytes(fileName);
    
    using (var stream = File.OpenWrite(fileName))
    {
        stream.Write(headerBytes, 0, headerBytes.Length);
        stream.Write(fileContent, 0, fileContent.Length);
    }
