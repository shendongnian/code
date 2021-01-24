    class program
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"Path to your xml file");
            var ids = doc.SelectNodes("//*[name()='feed']/*[name()='entry']/*[name()='id']/text()");
            foreach (XmlNode id in ids)
            {
                Console.WriteLine(id.Value);
            }
            Console.ReadLine();
        }
    }
