    public async void fileExist(string fileName)
    {
        try
        {
            //Creates "file.xml".
            StorageFile newBlankDocument = await KnownFolders.MusicLibrary.CreateFileAsync("file.xml", CreationCollisionOption.FailIfExists);
        }
        catch (Exception)
        {
    
        }
        try
        {
            //Creates "configFile.xml".
            StorageFile newDocument = await KnownFolders.MusicLibrary.CreateFileAsync(fileName, CreationCollisionOption.FailIfExists);
            //Gets the file
            StorageFile fileDocument = await KnownFolders.MusicLibrary.GetFileAsync(fileName);
    
            await Task.Run(async () =>
            {
                using (var fsFileStream = await fileDocument.OpenAsync(FileAccessMode.ReadWrite))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = false;
    
                    using (XmlWriter writer = XmlWriter.Create(fsFileStream.AsStreamForWrite(), settings))
                    {
                        //Create all the XML document fields.
                        writer.WriteStartDocument();
                        writer.WriteStartElement("Config");
                        writer.WriteStartElement("General");
                        writer.WriteAttributeString("name", "DATA");
                        writer.WriteStartElement("Local");
                        writer.WriteElementString("something1", "");
                        writer.WriteElementString("something2", "");
                        writer.WriteElementString("something3", "");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Dispose();
                    }
                }
            });
    
        }
        catch (Exception ex)
        {            
            //The file already exist and doesn´t need to be created again.
        }
    
    }
