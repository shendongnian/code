    class Program
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("XMLFile1.xml");
            foreach (XElement initial in doc.XPathSelectElements("//given-names"))
            {
                string v = initial.Value.Replace(".", ". ").TrimEnd(' ');
                initial.SetValue(v);
            }
            Console.WriteLine(doc.ToString());
        }
    }
