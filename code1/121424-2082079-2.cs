    using System;
    using System.IO;
    using System.Xml.Serialization;
    public class Foo
    {
        public int A { get; set; }
        public string B { get; set; }
        public int C { get; set; }
    }
    static class Program
    {
        static readonly XmlSerializer serializer;
        static Program()
        {
            XmlAttributeOverrides or = new XmlAttributeOverrides();
            or.Add(typeof(Foo), "A", new XmlAttributes { // change to an attrib
                XmlAttribute = new XmlAttributeAttribute("tweaked")
            });
            or.Add(typeof(Foo), "B", new XmlAttributes {
                XmlIgnore = true // turn this one off
            });
            // leave C as a default named element
            serializer = new XmlSerializer(typeof(Foo), or);
        }
        static void Main()
        {
            Foo foo = new Foo { A = 123, B = "def", C = 456 }, clone;
            string xml;
            using (StringWriter sw = new StringWriter())
            {
                serializer.Serialize(sw, foo);
                xml = sw.ToString();
            }
            using (StringReader sr = new StringReader(xml)) {
                clone = (Foo)serializer.Deserialize(sr);
            }
            Console.WriteLine(xml);
            Console.WriteLine();
            Console.WriteLine(clone.A);
            Console.WriteLine(clone.B);
            Console.WriteLine(clone.C);
        }
    }
