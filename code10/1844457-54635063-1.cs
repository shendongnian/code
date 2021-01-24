        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml("<p style=\"background-color:#eeeeee\">Hellow world</p>");
            var attributesofFirst = xml.ChildNodes[0].Attributes;
            attributesofFirst.RemoveNamedItem("style");
            Console.WriteLine(xml.ChildNodes[0].OuterXml); //<p>Hellow world</p>  
            Console.ReadLine();
        }
