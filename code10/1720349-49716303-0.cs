    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("input.xml");
            ReplaceValue(doc, "Outgoing Call", "Other value");
            doc.Save("output.xml");
        }
        
        static void ReplaceValue(XDocument doc, string original, string replacement)
        {
            foreach (var element in doc.Descendants("string").Where(x => x.Value == original))
            {
                element.Value = replacement;
            }
        }
    }
