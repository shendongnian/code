    using System.Collections.Generic;
    using System.IO;
    using System.Xml.Serialization;
    public class Foo {
        public List<Bar> Bars { get; set; }
    }  
    public class Bar {
        public string Widget { get; set; }
    }
    static class Program {
        static void Main() {
            XmlAttributeOverrides xOver = new XmlAttributeOverrides();
            xOver.Add(typeof(Foo), "Bars", new XmlAttributes {
                XmlArray = new XmlArrayAttribute("Bars"),
                XmlArrayItems = {
                    new XmlArrayItemAttribute("SomethingElse", typeof(Bar))
                }
            });
            XmlSerializer serializer = new XmlSerializer(typeof(Foo), xOver);
            using (var writer = new StringWriter()) {
                Foo foo = new Foo { Bars = new List<Bar> {
                    new Bar { Widget = "widget"}
                }};
                serializer.Serialize(writer, foo);
                string xml = writer.ToString();
            }            
        }
    }
