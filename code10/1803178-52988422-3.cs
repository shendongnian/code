    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"C:\Users\xxx\source\repos\ConsoleApp4\ConsoleApp4\Files\XMLFile14.xml");
            var registerEntries = doc.Descendants("RegisterEntry");
            var result = (from e in registerEntries
                          select new
                          {
                              EntryNumber = e.Element("EntryNumber") != null ? Convert.ToInt32(e.Element("EntryNumber").Value) : 0,
                              EntryDate = e.Element("EntryDate") != null ? Convert.ToDateTime(e.Element("EntryDate").Value) : (DateTime?)null,
                              EntryType = e.Element("EntryType") != null ? e.Element("EntryType").Value : "",
                              EntryText = e.Element("EntryText") != null ? e.Element("EntryText").Value : "",
                          }).ToList();
            foreach (var entry in result)
            {
                Console.WriteLine($"EntryNumber:  {entry.EntryNumber}");
                Console.WriteLine($"EntryDate:  {entry.EntryDate}");
                Console.WriteLine($"EntryType:  {entry.EntryType}");
                Console.WriteLine($"EntryText:  {entry.EntryText}");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
