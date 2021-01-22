    class Program
    {
        static void Main(string[] args)
        {
            string contents = string.Empty;
            XmlDocument document = new XmlDocument();
            document.LoadXml("<outer>a<b>b</b>c<i>d</i>e<b>f</b>g</outer>");
            foreach(XmlNode child in document.DocumentElement.ChildNodes)
            {
                if (child.NodeType == XmlNodeType.Element)
                {
                    contents += child.InnerText;
                }
            }
            Console.WriteLine(contents);
            Console.ReadKey();
        }
    }
