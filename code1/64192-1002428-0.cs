    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace Util
    {
        /// <summary>
        /// Not to be confused with System.Xml.Serialization.XmlSerializer, which this uses internally.
        /// 
        /// This will convert the public fields and properties of any object to and from an XML string, 
        /// unless they are marked with NonSerialized() and XmlIgnore() attributes.
        /// </summary>
        public class XMLSerializer
        {
            public static Byte[] GetByteArrayFromEncoding(Encoding encoding, string xmlString)
            {
                return encoding.GetBytes(xmlString);
            }
    
            public static String SerializeToXML<T>(T objectToSerialize)
            {
                return SerializeToXML(objectToSerialize, Encoding.UTF8);
            }
    
            public static String SerializeToXML<T>(T objectToSerialize, Encoding encoding)
            {
                StringBuilder sb = new StringBuilder();
    
                XmlWriterSettings settings =
                    new XmlWriterSettings { Encoding = encoding, Indent = true };
    
                using (XmlWriter xmlWriter = XmlWriter.Create(sb, settings))
                {
                    if (xmlWriter != null)
                    {
                        new XmlSerializer(typeof (T)).Serialize(xmlWriter, objectToSerialize);
                    }
                }
    
                return sb.ToString();
            }
    
            public static void DeserializeFromXML<T>(string xmlString, out T deserializedObject) where T : class
            {
                DeserializeFromXML(xmlString, new UTF8Encoding(), out deserializedObject);
            }
    
            public static void DeserializeFromXML<T>(string xmlString, Encoding encoding, out T deserializedObject) where T : class
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
    
                using (MemoryStream memoryStream = new MemoryStream(GetByteArrayFromEncoding(encoding, xmlString)))
                {
                    deserializedObject = xs.Deserialize(memoryStream) as T;
                }
            }
        }
    }
    
    public static void Main()
    {
        List<string> PopList = new List<string>{"asdfasdfasdflj", "asdflkjasdflkjasdf", "bljkzxcoiuv", "qweoiuslfj"};
        
        string xmlString = Util.XMLSerializer.SerializeToXML(PopList);
        
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlString);
    
        string fileName = @"C:\temp\test.xml";
        xmlDoc.Save(fileName);
        
        string xmlTextFromFile = File.ReadAllText(fileName);
        List<string> ListFromFile;
        
        Util.XMLSerializer.DeserializeFromXML(xmlTextFromFile, Encoding.Unicode, out ListFromFile);
        foreach(string s in ListFromFile)
        {
            Console.WriteLine(s);
        }
    }
