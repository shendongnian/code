    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    
    namespace XMLDeserializeTest
    {
        class Program
        {
            static int paragraphCount = 0;
            static void Main(string[] args)
            {
                string file = Environment.CurrentDirectory + @"\test.xml";
    
                paragraphCount = 0;
                test testClass = Deserialize(file);
    
            }
    
            static test Deserialize(string url)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(test));
                serializer.UnknownElement += serializer_UnknownElement;
                StreamReader stream = new StreamReader(url);
                return serializer.Deserialize(stream) as test;
            }
    
            static void serializer_UnknownElement(object sender, XmlElementEventArgs e)
            {            
                test t = (test)e.ObjectBeingDeserialized;
    
                if (e.Element.Name == "table")
                {
                    var s = new XmlSerializer(typeof(Table));
                    var sr = new StringReader(e.Element.OuterXml);
                    Table newTable = s.Deserialize(sr) as Table;               
                    newTable.nodeNumber = paragraphCount;
                    t.tables.Add(newTable);                
                }
                else if (e.Element.Name == "paragraph")
                {
                    String paragraphText = e.Element.InnerText;
                    t.paragraphs.Add(paragraphText);
                    paragraphCount++;
                }
            }
    
        }
    
        public class test
        {
            public List<string> paragraphs { get; set; }
            public List<Table> tables { get; set; }
    
            public test()
            {
    
            }
    
        }
    
        [Serializable, XmlRoot("table")]
        public class Table
        {
            [XmlElement("row")]
            public List<Row> rows { get; set; }
    
            public int nodeNumber { get; set; }  // This is what needs to be tracked
    
            public Table()
            {
    
            }
        }
    
        [Serializable, XmlRoot("row")]
        public class Row
        {
            [XmlElement("entry")]
            public List<string> entries { get; set; }
    
            public Row()
            {
    
            }
        }
    }
