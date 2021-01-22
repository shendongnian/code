        private XmlElement Serialize(object obj)
        {
            XmlElement serializedXmlElement = null;  
            try
            {
                System.IO.MemoryStream memoryStream = new MemoryStream();
                System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(obj.GetType());
                xmlSerializer.Serialize(memoryStream, obj);
                memoryStream.Position = 0;
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(memoryStream);
                serializedXmlElement = xmlDocument.DocumentElement;
            }
            catch (Exception e)
            {
                //logging statements. You must log exception for review
            }
            return serializedXmlElement; 
        }
