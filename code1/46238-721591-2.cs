    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Text;
    using System.IO;
    
    namespace Utils
    {
        public class XMLSerializer
        {
            public static Byte[] StringToUTF8ByteArray(String xmlString)
            {
                return new UTF8Encoding().GetBytes(xmlString);
            }
    
            public static String SerializeToXML<T>(T objectToSerialize)
            {
                StringBuilder sb = new StringBuilder();
    
                XmlWriterSettings settings = 
                    new XmlWriterSettings {Encoding = Encoding.UTF8, Indent = true};
    
                using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
                {
                    if (xmlWriter != null)
                    {
                        new XmlSerializer(typeof(T)).Serialize(xmlWriter, objectToSerialize);
                    }
                }
    
                return sb.ToString();
            }
    
            public static void DeserializeFromXML<T>(string xmlString, out T deserializedObject) where T : class
            {
                XmlSerializer xs = new XmlSerializer(typeof (T));
    
                using (MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString)))
                {
                    deserializedObject = xs.Deserialize(memoryStream) as T;
                }
            }
        }
    }
