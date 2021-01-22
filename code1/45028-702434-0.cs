    using System.Xml;
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument d = new XmlDocument();
            string xml =
                @"<NO>
      <L>Some text here </L>
      <L>Some additional text here </L>
      <L>Still more text here </L>
    </NO>";
            d.LoadXml(xml);
            Console.WriteLine(d.DocumentElement.InnerText);
            Console.ReadLine();
        }
    }
