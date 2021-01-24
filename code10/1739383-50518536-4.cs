    public static class XmlSerializationHelper
    {
        public static T LoadFromXml<T>(this string xmlString, XmlSerializer serial = null)
        {
            serial = serial ?? new XmlSerializer(typeof(T));
            using (var reader = new StringReader(xmlString))
            {
				return (T)serial.Deserialize(reader);
            }
        }
        public static string GetXml<T>(this T obj, XmlSerializer serializer = null)
        {
            using (var textWriter = new StringWriter())
            {
                var settings = new XmlWriterSettings() { Indent = true }; // For cosmetic purposes.
                using (var xmlWriter = XmlWriter.Create(textWriter, settings))
                    (serializer ?? new XmlSerializer(obj.GetType())).Serialize(xmlWriter, obj);
                return textWriter.ToString();
            }
        }
    }
