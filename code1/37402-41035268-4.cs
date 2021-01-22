    public class AbstractXmlSerializer<AbstractType> where AbstractType : class
    {
        private Dictionary<String, Type> typeMap;
        public AbstractXmlSerializer(List<Type> types)
        {            
            typeMap = new Dictionary<string, Type>();
            foreach (Type type in types)
            {
                if (type.IsSubclassOf(typeof(AbstractType))) {
                    object[] attributes = type.GetCustomAttributes(typeof(XmlTypeAttribute), false);
                    if (attributes != null && attributes.Count() > 0)
                    {
                        XmlTypeAttribute attribute = attributes[0] as XmlTypeAttribute;
                        typeMap[attribute.TypeName] = type;
                    }
                }
            }
        }
        public AbstractType Deserialize(String xmlData)
        {
            if (string.IsNullOrEmpty(xmlData))
            {
                throw new ArgumentException("xmlData parameter must contain xml");
            }            
            // Read the Data, Deserializing based on the (now known) concrete type.
            using (StringReader stringReader = new StringReader(xmlData))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader))
                {
                    String targetType = GetRootElementName(xmlReader);
                    if (targetType == null)
                    {
                        throw new InvalidOperationException("XML root element was not found");
                    }                        
                    AbstractType result = (AbstractType)new
                        XmlSerializer(typeMap[targetType]).Deserialize(xmlReader);
                    return result;
                }
            }
        }
        private static string GetRootElementName(XmlReader xmlReader)
        {            
            if (xmlReader.IsStartElement())
            {
                return xmlReader.Name;
            }
            return null;
        }
    }
