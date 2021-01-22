    public static T FromXml<T>(string xmlString){
            Type sourceType;
            using (var stringReader = new StringReader(xmlString)) {
                var rootNodeName = XElement.Load(stringReader).Name.LocalName;
                sourceType =
                    Assembly.GetExecutingAssembly().GetTypes()
                        .FirstOrDefault(t => t.IsSubclassOf(typeof(T)) && t.Name == rootNodeName)
                    ??
                    Assembly.GetAssembly(typeof(T)).GetTypes()
                        .FirstOrDefault(t => t.IsSubclassOf(typeof(T)) && t.Name == rootNodeName);
                if (sourceType == null) {
                    throw new Exception();
                }
            }
            using (var stringReader = new StringReader(xmlString)) {
                if (sourceType.IsSubclassOf(typeof(T)) || sourceType == typeof(T)) {
                    var ser = new XmlSerializer(sourceType);
                    using (var xmlReader = new XmlTextReader(stringReader)) {
                        T obj;
                        obj = (T)ser.Deserialize(xmlReader);
                        xmlReader.Close();
                        return obj;
                    }
                } else {
                    throw new InvalidCastException(sourceType.FullName + " cannot be cast to " + typeof(T).FullName);
                }
            }
        }
