    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.IO;
    using System.Xml;
    
    namespace XmlSerialiserTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlTextWriter xmlWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(TestClass));
                TestClass domain = new TestClass(10, 3);
                xmlSerializer.Serialize(xmlWriter, domain);
                memoryStream = (MemoryStream)xmlWriter.BaseStream;
                string xmlSerializedString = UTF8ByteArrayToString(memoryStream.ToArray());
    
                TestClass xmlDomain = (TestClass)DeserializeObject(xmlSerializedString);
    
                Console.WriteLine(xmlDomain.TestFunction().ToString());
                Console.ReadLine();
            }
            private static String UTF8ByteArrayToString(Byte[] characters)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                String constructedString = encoding.GetString(characters);
                return (constructedString);
            }
            private static Byte[] StringToUTF8ByteArray(String pXmlString)
            {
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(pXmlString);
                return byteArray;
            }
            public static Object DeserializeObject(String pXmlizedString)
            {
                XmlSerializer xs = new XmlSerializer(typeof(TestClass));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return xs.Deserialize(memoryStream);
            }        
        }
        [Serializable]
        public class TestClass
        {
            int x = 2;
            int y = 4;
            public TestClass(){}
            public TestClass(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
    
            public int TestFunction()
            {
                return x + y;
            }
        }
    }
