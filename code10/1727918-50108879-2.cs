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
    }
