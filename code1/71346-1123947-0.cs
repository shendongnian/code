    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version='1.0'?><response><error code='1'> Success</error></response>";
            XDocument doc = XDocument.Parse(xml);
            Console.WriteLine(doc.ToString());
        }
    }
