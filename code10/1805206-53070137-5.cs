    public class Xml
    {
    	public static string Serialize<T>(T obj)
            {
                var xmlSerializer = new XmlSerializer(obj.GetType());
                using (var textWriter = new StringWriter())
                {
                    xmlSerializer.Serialize(textWriter, obj);
                    return textWriter.ToString();
                }
            }
    }
