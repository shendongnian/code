    using System.Xml.XPath;
    class Program
    {
        static void Main(string[] args)
        {
            var elements = XElement
                .Load("test.xml")
                .XPathSelectElements("//media/media-object[@encoding='base64']");
            foreach (var element in elements)
            {
                byte[] image = Convert.FromBase64String(element.Value);
            }
        }
    }
