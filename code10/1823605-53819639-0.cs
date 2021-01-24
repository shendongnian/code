        public static class XMLFactory
    {
        public static T XmlDeserializeFromString<T>(this string objectData)
        {
            return (T)XmlDeserializeFromString(objectData, typeof(T));
        }
        public static object XmlDeserializeFromString(this string objectData, Type type)
        {
            try
            {
                var serializer = new XmlSerializer(type);
                object result;
                using (TextReader reader = new StringReader(objectData))
                {
                    result = serializer.Deserialize(reader);
                }
                return result;
            }
            catch (Exception ex)
            {
                LoggerHelper.LogError(ex.ToString());
                return null;
            }
        }
        public static string XmlSerializeToString(this object objectInstance)
        {
            var serializer = new XmlSerializer(objectInstance.GetType());
            var sb = new StringBuilder();
            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }
            return sb.ToString();
        }
    }
