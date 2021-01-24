    public class CustomXMLPropertyClass
    {
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
    }
    private static void AddCustomXmlPartCustomPropertyToSlidePart(string propertyName, string propertyValue, SlidePart part)
    {
        var customXmlPart = part.AddCustomXmlPart(CustomXmlPartType.CustomXml);
        var customProperty = new CustomXMLPropertyClass{ PropertyName = propertyName, PropertyValue = propertyValue };
        var serializer = new System.Xml.Serialization.XmlSerializer(customProperty.GetType());
        var stream = new MemoryStream();
        serializer.Serialize(stream, customProperty);
        var customXml = System.Text.Encoding.UTF8.GetString(stream.ToArray());
        using ( var streamWriter = new StreamWriter(customXmlPart.GetStream()))
        {
            streamWriter.Write(customXml);
            streamWriter.Flush();
        }
    }
