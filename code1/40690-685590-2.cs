    // Loading from a file, you can also load from a stream
    var doc = XDocument.Load(@"C:\contacts.xml");
    
    
    // Query the data and write out a subset of contacts
    var query = from c in doc.Root.Descendants("contact")
                where (int)c.Attribute("contactId") < 4
                select c.Element("firstName").Value + " " +
                       c.Element("lastName").Value;
    
    
    foreach (string name in query)
    {
        Console.WriteLine("Contact's Full Name: {0}", name);
    }
