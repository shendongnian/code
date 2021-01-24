    private static string GetCustomXmlPropertyFromCustomXmlPart(CustomXmlPart customXmlPart)
    {
        var customXmlProperty = new CustomXMLPropertyClass();
        string xml = "";
    
        using (var stream = customXmlPart.GetStream())
        {
            var streamReader = new StreamReader(stream);
            xml = streamReader.ReadToEnd();
        }
    
        using (TextReader reader = new StringReader(xml))
        {
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(customXmlProperty));
            customXmlProperty = (CustomXMLPropertyClass)serializer.Deserialize(reader);
        }
    
        var chartToolType = customXmlProperty.PropertyValue;
    
        return chartToolType;
    }
