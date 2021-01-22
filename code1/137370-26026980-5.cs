        public static T XmlDeserialize<T>(this string toDeserialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using(StringReader textReader = new StringReader(toDeserialize))
            {      
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }
        public static string XmlSerialize<T>(this T toSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using(StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, toSerialize);
                return textWriter.ToString();
            }
        }
        public static T JsonDeserialize<T>(this string toDeserialize)
        {
            return JsonConvert.DeserializeObject<T>(toDeserialize);
        }
        public static string JsonSerialize<T>(this T toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }
