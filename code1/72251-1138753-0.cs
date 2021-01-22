    new XElement("people", myPeople.ToXNodes());
---
    
    public static class XmlTools
    {
        public static XElement ToXNode<T>(this T input)
        {
            return XElement.Parse(input.ToString());
        }
        public static IEnumerable<XElement> ToXNodes<T>(this IEnumerable<T> input)
        {
            foreach (var item in input)
                yield return input.ToXNode();
        }
        public static IEnumerable<string> ToXmlString<T>(this IEnumerable<T> input)
        {
            foreach (var item in input)
                yield return item.ToXmlString();
        }
        public static string ToXmlString<T>(this T input)
        {
            using (var writer = new StringWriter())
            {
                input.ToXml(writer);
                return writer.ToString();
            }
        }
        public static void ToXml<T>(this T objectToSerialize, Stream stream)
        {
            new XmlSerializer(typeof(T)).Serialize(stream, objectToSerialize);
        }
    
        public static void ToXml<T>(this T objectToSerialize, StringWriter writer)
        {
            new XmlSerializer(typeof(T)).Serialize(writer, objectToSerialize);
        }
    }
