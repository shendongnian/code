        static void Main(string[] args)
        {
            string xml = "<root><item><title><p>some title</p></title></item></root>";
            XDocument xdoc = XDocument.Parse(xml);
            XElement te = xdoc.Descendants("title").First();
            using (XmlReader reader = te.CreateReader())
            {
                if (reader.Read())
                    title = reader.ReadInnerXml();
            }
        }
