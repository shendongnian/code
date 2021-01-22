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
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("","");
                foreach (Foo foo in FooGenerator()) {
                    ser.Serialize(xw, foo, ns);
                }
                xw.WriteEndElement();
            }
        }    
        // streaming approach; only have the smallest amount of program
        // data in memory at once - in this case, only a single `Foo` is
        // ever in use at a time
        static IEnumerable<Foo> FooGenerator() {
            for (int i = 0; i < 40; i++) {
                yield return new Foo { Id = i, Bar = "Foo " + i };
            }
        }
    }
