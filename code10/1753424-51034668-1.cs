    class Program
    {
        public static void Main(string[] args)
        {
            List<Rate> rates = new List<Rate>();
            var doc = new XmlDocument();
            doc.Load(@"http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");
            XmlNodeList nodes = doc.SelectNodes("//*[@currency]");
            if (nodes != null)
            {
                foreach (XmlNode node in nodes)
                {
                    var rate = new Rate()
                               {
                                  Currency = node.Attributes["currency"].Value,
                                  Value = Decimal.Parse(node.Attributes["rate"].Value, NumberStyles.Any, new CultureInfo("en-Us"))
                               };
                    rates.Add(rate);
                }
            }
        }
    }
    class Rate
    {
        public string Currency { get; set; }
        public decimal Value { get; set; }
    }
 
