    class Program
    {
        static void Main(string[] args)
        {
            List<Rate> rates = new List<Rate>();
            var doc = new XmlDocument();
            doc.Load(@"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            XmlNodeList nodes = doc.SelectNodes("/*/*/*/*");
            for (int i = 0; i < nodes.Count; i++)
            {
                var rate = new Rate()
                {
                    Currency = nodes[i].Attributes[0].Value,
                    Value = Decimal.Parse(nodes[i].Attributes[1].Value)
                };
                rates.Add(rate);
            }
            Console.WriteLine();
        }
    }
    class Rate
    {
        public string Currency { get; set; }
        public decimal Value { get; set; }
    }
