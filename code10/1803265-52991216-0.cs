    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication75
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
               string xml = "<AddJob>" +
                  "<AddJob RequestStatus=\"OK\" RequestMessage=\"Job successfuly added [testPrintServer.tif, PES_Carpet_16C_76.2 x 50.8 dpi_170517_Normal]\" UUID=\"74ad5971-7baf-49ce-b85b-ee08188d5721\" />" +
                  "</AddJob>";
               Root job = XmlHelper.Deserialize<Root>(xml);
     
            }
     
        }
        public class XmlHelper
        {
            public static T Deserialize<T>(string xml)
            {
                var serializer = new XmlSerializer(typeof(T));
                T result;
                using (var reader = new StringReader(xml))
                {
                    result = (T)serializer.Deserialize(reader);
                }
                return result;
            }
        }
        [XmlRoot("AddJob")]
        public class Root
        {
            public AddJob AddJob { get; set; }
        }
        public class AddJob
        {
            [XmlAttribute]
            public string RequestStatus { get; set; }
            [XmlAttribute]
            public string RequestMessage { get; set; }
            [XmlAttribute("UUID")]
            public string RipJobId { get; set; }
        }
     
    }
