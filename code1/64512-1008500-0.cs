    using System.Xml;
    
    void WriteXMLForAllFiles(string directory, string outputFilePath)
    {
        XmlWriterSettings settings = new XmlWriterSettings();
        settings.Indent = true;
                
        XmlWriter writer = XmlTextWriter.Create(outputFilePath, settings);
    
        writer.WriteStartDocument();
        writer.WriteStartElement("Files");
    
        foreach( string file in Directory.GetFiles(directory, "*.*", SearchOptions.AllDirectories) )
        {
            FileInfo fileInfo = new FileInfo(file);
            writer.WriteStartElement("file");
    
            writer.WriteAttributeString("path", file);
            writer.WriteAttributeString("creationTime", fileInfo.CreationTimeUtc.ToString());
            writer.WriteAttributeString("lastWriteTime", fileInfo.LastWriteTimeUtc.ToString());
    
            writer.WriteEndElement();
        }
    
        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();
    }
