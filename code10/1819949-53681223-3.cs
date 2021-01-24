    class program
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load(@"Path to your xml file");
            var result = from d in doc.Descendants("DATASET").Elements("DS")
                         select new
                         {
                             Name = d.Element("Name")?.Value,
                             Price = d.Element("Price")?.Value,
                             Dates = d.Element("Dates")?.Value,
                             Quantity = d.Element("Quantity").Value,
                             Total = d.Element("Quantity") != null && d.Element("Price") != null ? Convert.ToInt32(d.Element("Quantity").Value) * Convert.ToInt32(d.Element("Price").Value) : 0,
                             Notes = d.Element("Notes")?.Value,
                         };
            XDocument newDoc =
                new XDocument(
                    new XElement("DATASET",
                    result.Select(x => new XElement("DS",
                        new XElement("Name", x.Name),
                        new XElement("Price", x.Price),
                        new XElement("Dates", x.Dates),
                        new XElement("Quantity", x.Quantity),
                        new XElement("Total", x.Total),
                        new XElement("Notes", x.Notes)))));
            newDoc.Save(@"updated.xml");
        }
    }
