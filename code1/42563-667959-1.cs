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
            public static String UTF8ByteArrayToString(Byte[] characters)
            {
                return new UTF8Encoding().GetString(characters);
            }
    
            public static Byte[] StringToUTF8ByteArray(String xmlString)
            {
                return new UTF8Encoding().GetBytes(xmlString);
            }
    
            public static String SerializeToXML<T>(T objectToSerialize)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    XmlSerializer xs = new XmlSerializer(typeof(T));
    
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8))
                    {
                        xmlTextWriter.Formatting = Formatting.Indented;
    
                        xs.Serialize(xmlTextWriter, objectToSerialize);
    
                        return UTF8ByteArrayToString(memoryStream.ToArray());
                    }
                }
            }
    
            public static void DeserializeFromXML<T>(string xmlString, out T deserializedObject) where T : class
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
    
                using (MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xmlString)))
                {
                    deserializedObject = xs.Deserialize(memoryStream) as T;
                }
            }
        }
    }
