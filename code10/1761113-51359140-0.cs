    class Program
    {
        static void Main(string[] args)
        {
            XmlMapper xmlMapper = new XmlMapper("xml.xml");
            Console.WriteLine("TEST WITHOUT BLACKLIST:\n");
            xmlMapper.PrintMap();
            Console.WriteLine("\nTEST WITH BLACKLIST:\n");
            xmlMapper.PrintMap(new List<string>() { "P" });
        }
    }
    class XmlMapper
    {
        public string FilePath { get; private set; }
        public XDocument XDocument { get; private set; }
        public XmlMapper(string filePath)
        {
            LoadXML(filePath);
        }
        public void LoadXML(string filePath)
        {
            this.FilePath = filePath;
            this.XDocument = XDocument.Load(FilePath);
        }
        public void PrintMap(List<string> blacklist = null)
        {
            PrintElements(XDocument.Elements().ToList(), "", blacklist);
        }
        private void PrintElements(List<XElement> elements, string path, List<string> blacklist = null)
        {
            foreach (XElement element in elements)
            {
                string elementPath = path + "\\" + element.Name;
                if (blacklist != null && blacklist.Contains(element.Name.LocalName) == true)
                {
                    Console.WriteLine(string.Format("{0} = {1}", elementPath, element?.ToString()));
                    continue;
                }
                else
                {
                    Console.WriteLine(string.Format("{0} = {1}", elementPath, element?.Value));
                }
                if (element.HasElements)
                {
                    PrintElements(element.Elements().ToList(), elementPath, blacklist);
                }
            }
        }
    }
