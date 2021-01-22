    class Program
    {
        static void Main(string[] args)
        {
            Program.Process(XDocument.Load(@"C:\test.xml").Root);
            Console.Read();
        }
    
        static void Process(XElement element)
        {
            if (!element.HasElements)
            {
                Console.WriteLine(element.GetAbsoluteXPath());
            }
            else
            {
                foreach (XElement child in element.Elements())
                {
                    Process(child);
                }
            }
        }
    }
