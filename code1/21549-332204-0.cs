        using System;
        using System.Xml;
        static void Main(string[] args)
        {
            XmlDocument d = new XmlDocument();
            XmlElement e = d.CreateElement("elm");
            d.AppendChild(e);
            d.DocumentElement.SetAttribute("xmlns:a", "my_namespace");
            e = d.CreateElement("a", "bar", "my_namespace");
            d.DocumentElement.AppendChild(e);
            e = d.CreateElement("a", "baz", "other_namespace");
            d.DocumentElement.AppendChild(e);
            e = d.CreateElement("b", "bar", "my_namespace");
            d.DocumentElement.AppendChild(e);
            d.Save(Console.Out);
            Console.ReadLine();
        }
