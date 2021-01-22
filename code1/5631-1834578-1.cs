    static public class SerializeHelper
    {
      //Michael White, Holly Springs Consulting, 2009
      //michael@hollyspringsconsulting.com
        public static T DeserializeXML<T>(string xmlData)
            where T:new()
        {
            if (string.IsNullOrEmpty(xmlData))
                return default(T);
            TextReader tr = new StringReader(xmlData);
            T DocItms = new T();
            XmlSerializer xms = new XmlSerializer(DocItms.GetType());
            DocItms = (T)xms.Deserialize(tr);
            return DocItms == null ? default(T) : DocItms;
        }
        public static string SeralizeObjectToXML<T>(T xmlObject)
        {
            StringBuilder sbTR = new StringBuilder();
            XmlSerializer xmsTR = new XmlSerializer(xmlObject.GetType());
            XmlWriterSettings xwsTR = new XmlWriterSettings();
            
            XmlWriter xmwTR = XmlWriter.Create(sbTR, xwsTR);
            xmsTR.Serialize(xmwTR,xmlObject);
            
            return sbTR.ToString();
        }
        public static T CloneObject<T>(T objClone)
            where T:new()
        {
            string GetString = SerializeHelper.SeralizeObjectToXML<T>(objClone);
            return SerializeHelper.DeserializeXML<T>(GetString);
        }
    }
