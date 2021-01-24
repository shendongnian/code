    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load(@"You xml document path");
    
            var result = (from o in doc.Descendants("SignalData")
                          from i in o.Descendants("Signal")
                          select new
                          {
                              dataWidth = o.Attribute("DataWidth").Value.Substring(0, o.Attribute("DataWidth").Value.IndexOf(" ")),
                              period = o.Attribute("SamplingPeriod").Value.Substring(0, o.Attribute("SamplingPeriod").Value.IndexOf(" ")),
                              Id = i.Elements("Id").Select(item => (string)item).FirstOrDefault(),
                              InitState = i.Elements("InitState").Select(item => (string)item).FirstOrDefault(),
                              cdata = i.Value
                          }).ToList();
    
            foreach (var item in result)
            {
                Console.WriteLine($"dataWidth: { item.dataWidth}, \t period: {item.period}, \t Id: {item.Id}, \t InitState: {item.InitState}");
            }
    
            Console.ReadLine();
        }
    }
    
