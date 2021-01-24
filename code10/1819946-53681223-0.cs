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
            foreach (var item in result)
            {
                Console.WriteLine("Total: " + item.Total);
            }
            Console.Read();
        }
    }
