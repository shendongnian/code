    //The Xsd_whithout_saved() is not working
    //In Xsd_whithout_saved(), every place I need the XSD, I got from variable StreamReader named readerXsd whitch come from a string 
    public void  Xsd_whithout_saved()
    {
        //>>>Here is the biggest diference from the method Xsd_after_saved: I manipulate the XSD as string because it will come from database and 
        //it will not allowed to be saved locally
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(@"C:\book.xsd");
        //In the futute, strArquivoInteiro will be fullfill by xsd comming from database as nvarchar(max) and I will not be allowed to save as a file locally
        string strArquivoInteiro = xmlDoc.OuterXml;
        byte[] byteArray = Encoding.ASCII.GetBytes(strArquivoInteiro);
        using (MemoryStream streamXSD = new MemoryStream(byteArray))
        using (StreamReader readerXsd = new StreamReader(streamXSD))
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationEventHandler += this.ValidationEventHandler;
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas.Add(null, XmlReader.Create(readerXsd));
            settings.CheckCharacters = true;
            using (XmlReader XmlValidatingReader = XmlReader.Create(@"C:\book.xml", settings))
            using (XmlTextReader Reader = new XmlTextReader(@"C:\book.xml"))
            {
                XmlSchema Schema = new XmlSchema();
                streamXSD.Seek(SeekOrigin.Begin, 0);
                Schema = XmlSchema.Read(readerXsd, ValidationEventHandler);
                XmlValidatingReader ValidatingReader = new XmlValidatingReader(Reader);
                ValidatingReader.ValidationType = ValidationType.Schema;
                ValidatingReader.Schemas.Add(Schema);
                try
                {
                    XmlValidatingReader.Read();
                    XmlValidatingReader.Close();
                    ValidatingReader.ValidationEventHandler += ValidationEventHandler;
                    while ((ValidatingReader.Read()))
                    {
                    }
                    
                    ValidatingReader.Close();
                }
                catch (Exception ex)
                {
                    ValidatingReader.Close();
                    XmlValidatingReader.Close();
                }
            }
        }
    }
