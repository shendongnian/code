    // Loading from a file, you can also load from a stream
    var xml = XDocument.Load(@"C:\contacts.xml");
    
    
    // Query the data and write out a subset of contacts
    var query = from c in xml.Root.Descendants("contact")
                where (int)c.Attribute("id") < 4
                select c.Element("firstName").Value + " " +
                       c.Element("lastName").Value;
    
    
    foreach (string name in query)
    {
        Console.WriteLine("Contact's Full Name: {0}", name);
    }
