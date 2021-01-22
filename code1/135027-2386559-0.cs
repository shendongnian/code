    using System.Xml.Serialization;
    using System;
    public class Foo
    {
        public string Bar { get; set; }
        static void Main()
        {
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlSerializer ser = new XmlSerializer(typeof(Foo));
            ser.Serialize(Console.Out, new Foo { Bar = "abc" }, ns);
        }
    }
