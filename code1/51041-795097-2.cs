    using System.Linq;
    using System.Xml.Linq;
    namespace SO_794331
    {
        class Program
        {
            static void Main(string[] args)
            {
                var docA = XDocument.Parse(
                    @"<root xmlns:ns=""http://myNs""><ns:child>1</ns:child></root>");
                var docB = XDocument.Parse(
                    @"<root><child xmlns=""http://myNs"">1</child></root>");
    
                var rootNameA = docA.Root.Name;
                var rootNameB = docB.Root.Name;
                var equalRootNames = rootNameB.Equals(rootNameA);
    
                var descendantsA = docA.Root.Descendants();
                var descendantsB = docB.Root.Descendants();
                for (int i = 0; i < descendantsA.Count(); i++)
                {
                    var descendantA = descendantsA.ElementAt(i);
                    var descendantB = descendantsB.ElementAt(i);
                    var equalChildNames = descendantA.Name.Equals(descendantB.Name);
    
                    var valueA = descendantA.Value;
                    var valueB = descendantB.Value; // edited by valamas - was descendantA.Value
                    var equalValues = valueA.Equals(valueB);
                }
            }
        }
    }
