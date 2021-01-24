    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    
    namespace Rextester
    {
        
        [XmlRoot("root", Namespace = "ns1")]
        public partial class Test 
        {
            [XmlArray(ElementName = "Group", Namespace = "")]
            public Item[] Group { get; set; }
        }
    
        public partial class Item
        {
            public int Value { get; set; }
        }
    
         public class Program
        {
            public static void Main(string[] args)
            {
                var t = new Test();
                t.Group = new Item[] { new Item { Value = 5 }, new Item { Value = 10 } };
                XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
                xsn.Add("n1", "ns1");
                var serializer = new XmlSerializer(typeof(Test));
                serializer.Serialize(Console.Out, t,xsn);
            }
        }
    }
