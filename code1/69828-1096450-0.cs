    using System;
    using System.Xml.Serialization;
    [XmlRoot(Namespace="flibblecorp")]
    public class Foo {
        public string Bar { get; set; }
        static void Main() {
            Foo obj = new Foo { Bar = "abc"};
            XmlSerializer ser = new XmlSerializer(typeof(Foo));
            ser.Serialize(Console.Out, obj); // output 1
            Console.WriteLine();
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("soapenv", "flibblecorp");
            ser.Serialize(Console.Out, obj, ns); // output 2
        }
    }
