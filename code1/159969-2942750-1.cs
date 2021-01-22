    string server = "tcp://myserver"
    string message = "GetMyXml"
    int port = 13000;
    int bufferSize = 1024;
    
    using(var client = new TcpClient(server, port))
    using(var clientStream = client.GetStream())
    using(var bufferedStream = new BufferedStream(clientStream, bufferSize))
    using(var xmlReader = XmlReader.Create(bufferedStream))
    {
        xmlReader.MoveToContent();
        try
        {
            while(xmlReader.Read())
            {
                // Check for XML declaration.
                if(xmlReader.NodeType != XmlNodeType.XmlDeclaration)
                {
                    throw new Exception("Expected XML declaration.");
                }
        
                // Move to the first element.
                xmlReader.Read();
                xmlReader.MoveToContent();
        
                // Read the root element.
                // Hand this document to another method to process further.
                var xmlDocument = XmlDocument.Load(xmlReader.ReadSubtree());
            }
        }
        catch(XmlException ex)
        {
            // Record exception reading stream.
            // Move reader to start of next document or rethrow exception to exit.
        }
    }
