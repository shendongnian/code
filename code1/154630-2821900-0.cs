    var doc = new XmlDocument();
    doc.Load("TheFile.xml");
    
    var basket = XmlDeserialize<Basket>(doc.OuterXml);
    public static T XmlDeserialize<T>(string serializedContent)
    {
        T returnValue;
    
        if (String.IsNullOrEmpty(serializedContent))
        {
            returnValue = default(T);
        }
        else
        {
            var deSerializer = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(serializedContent);
    
            try
            {
                returnValue = (T)deSerializer.Deserialize(stringReader);
            }
            catch (InvalidOperationException)
            {
                returnValue = default(T);
            }
        }
    
        return returnValue;
    }
