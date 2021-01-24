    public static partial class XmlSerializerExtensions
    {
        public static T ToObject<T>(this XContainer doc, XmlSerializer serializer = null)
        {
            if (doc == null)
                throw new ArgumentNullException();
            using (var reader = doc.CreateReader())
            {
                return (T)(serializer ?? new XmlSerializer(typeof(T))).Deserialize(reader);
            }
        }
    }
    [XmlRoot(ElementName = "KeyValueOfstringstring", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
    public class KeyValueOfstringstring
    {
        [XmlElement(ElementName = "Key", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string Key { get; set; }
        [XmlElement(ElementName = "Value", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public string Value { get; set; }
    }
    [XmlRoot(ElementName = "ArrayOfKeyValueOfstringstring", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
    public class ArrayOfKeyValueOfstringstring
    {
        [XmlElement(ElementName = "KeyValueOfstringstring", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
        public List<KeyValueOfstringstring> KeyValueOfstringstring { get; set; }
    }
