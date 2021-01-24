    class Program
    {
        const string FILENAME = @"c:\temp\test.xml";
        static void Main(string[] args)
        {
            XElement doc = XElement.Load(FILENAME);
            List<Product> products = doc.Descendants("Product").Select(x => new Product()
            {
                refCode = (string)x.Element("RefCode"),
                siteCode = x.Elements("SiteCode").Select(y => (int)y).ToArray(),
                status = (string)x.Element("Status")
            }).ToList();
        }
    }
    public class Product
    {
        public string refCode { get; set; }
        public int[] siteCode { get; set; }
        public string status { get; set; }
    }
}
