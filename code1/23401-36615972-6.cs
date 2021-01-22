    public static T DeserializeXml<T>(this string @this, string innerStartTag = null)
            {
                using (var stringReader = new StringReader(@this))
                using (var xmlReader = XmlReader.Create(stringReader)) {
                    if (innerStartTag != null) {
                        xmlReader.ReadToDescendant(innerStartTag);
                        var xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(innerStartTag));
                        return (T)xmlSerializer.Deserialize(xmlReader.ReadSubtree());
                    }
                    return (T)new XmlSerializer(typeof(T)).Deserialize(xmlReader);
                }
            }
