    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Serialization;    
    public class Foo {
        [XmlAttribute]
        public int Id { get; set; }
        public string Bar { get; set; }
    }
    static class Program {
        [STAThread]
        static void Main() {
            using (XmlWriter xw = XmlWriter.Create("out.xml")) {
                xw.WriteStartElement("xml");
                XmlSerializer ser = new XmlSerializer(typeof(Foo));
                XmlWriterSettings settings = new XmlWriterSettings();
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("","");
                settings.OmitXmlDeclaration = true;
                foreach (Foo foo in FooGenerator()) {
                    ser.Serialize(xw, foo, ns);
                }
                xw.WriteEndElement();
            }
        }    
        static IEnumerable<Foo> FooGenerator() {
            for (int i = 0; i < 40; i++) {
                yield return new Foo { Id = i, Bar = "Foo " + i };
            }
        }
    }
