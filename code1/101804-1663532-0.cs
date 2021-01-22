    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;
    using System.Linq;
    
    class Test    
    {    
        static void Main()
        {
            XNamespace nsAtom = "http://www.w3.org/2005/Atom";
            var feed = XElement.Load("test.xml");
            Console.WriteLine(feed.Descendants(nsAtom + "entry").Count());
        }
    }
