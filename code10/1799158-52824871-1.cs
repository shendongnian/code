    XElement xelement = XElement.Load(@"e:\test\x2.xml");
               
                IEnumerable<XElement> textSegs =
                     from seg in xelement.Descendants("DELIVERIES")
                      select seg;
    
                foreach (var address in textSegs)
                {
                    Console.WriteLine(address.Element("ADD1").Value);
                    Console.WriteLine(address.Element("CITY").Value);
                    Console.WriteLine(address.Element("ZIP").Value);
                    
                }
    
               
                Console.ReadKey();
