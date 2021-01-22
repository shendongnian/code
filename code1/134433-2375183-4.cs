    using System;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = new XDocument(
            new XComment("This is a comment"),
            new XElement("Root",
                new XElement("Child1", "data1"),
                new XElement("Child2", "data2")
                )
                );
    
            var builder = new StringBuilder();
            var settings = new XmlWriterSettings()
            {
                Indent = true
            };
            using (var writer = XmlWriter.Create(builder, settings))
            {
                doc.WriteTo(writer);
            }
            Console.WriteLine(builder.ToString());
        }
    }
