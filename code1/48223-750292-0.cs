     public class Serialization
        {
            /// <summary>
            /// Serializes the object.
            /// </summary>
            /// <param name="myObject">My object.</param>
            /// <returns></returns>
            public static XmlDocument SerializeObject(Object myObject)
            {
                XmlDocument XmlObject = new XmlDocument();
                String XmlizedString = string.Empty;
    
                try
                {                
                    MemoryStream memoryStream = new MemoryStream();
                    XmlSerializer xs = new XmlSerializer(myObject.GetType());
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                    xs.Serialize(xmlTextWriter, myObject);
                    memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                    XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());                
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e);
                }
                XmlObject.LoadXml(XmlizedString);
                return XmlObject;            
            }
    
            /// <summary>
            /// Deserializes the object.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="XmlizedString">The p xmlized string.</param>
            /// <returns></returns>
            public static T DeserializeObject<T>(String XmlizedString)
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(XmlizedString));
                //XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                Object myObject = xs.Deserialize(memoryStream);
                return (T)myObject;
            } 
    
            /// <summary>
            /// To convert a Byte Array of Unicode values (UTF-8 encoded) to a complete String.
            /// </summary>
            /// <param name="characters">Unicode Byte Array to be converted to String</param>
            /// <returns>String converted from Unicode Byte Array</returns>
            private static String UTF8ByteArrayToString(Byte[] characters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                String constructedString = encoding.GetString(characters);
                return (constructedString);
            }
    
    
    
            /// <summary>
            /// Converts the String to UTF8 Byte array and is used in De serialization
            /// </summary>
            /// <param name="pXmlString"></param>
            /// <returns></returns>
            private static Byte[] StringToUTF8ByteArray(String pXmlString)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(pXmlString);
                return byteArray;
            } 
        }
