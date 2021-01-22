    class Program
    {
        static void Main(string[] args)
        {
            var root = XDocument.Load(@"C:\test.xml").Root;
    
            Program.Process(root, 0);
            Console.Read();
        }
    
        static void Process(XElement element, int depth)
        {
            // For simplicity, argument validation not performed
    
            if (!element.HasElements)
            {
                // Reached the deepest child
                Console.WriteLine(element.GetAbsoluteXPath());
            }
            else
            {
                // element has children
    
                depth++;
    
                foreach (XElement child in element.Elements())
                {
                    Process(child, depth);
                }
    
                depth--;
            }
        }
    }
