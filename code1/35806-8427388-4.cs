    It's also possible through XmlSerialization.
    The idea is - serialize to XML and then readXml method of DataSet.
    
    I use this code (from an answer in SO, forgot where)
    
            public static string SerializeXml<T>(T value) where T : class
        {
            if (value == null)
            {
                return null;
            }
    
            XmlSerializer serializer = new XmlSerializer(typeof(T));
    
            XmlWriterSettings settings = new XmlWriterSettings();
            
            settings.Encoding = new UnicodeEncoding(false, false);
            settings.Indent = false;
            settings.OmitXmlDeclaration = false;
            // no BOM in a .NET string
    
            using (StringWriter textWriter = new StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
                {
                   serializer.Serialize(xmlWriter, value);
                }
                return textWriter.ToString();
            }
        }
    
    so then it's as simple as:
    
                string xmlString = Utility.SerializeXml(trans.InnerList);
    
            DataSet ds = new DataSet("New_DataSet");
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            { 
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                ds.ReadXml(reader); 
            }
    
    Not sure how it stands against all the other answers of this post, but it's also a possibility.
