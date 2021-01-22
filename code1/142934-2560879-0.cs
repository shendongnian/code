    var xml = XElement.Parse(@"<abc>
      <foo>data testing</foo>
      <foo>test data</foo>
      <bar>data value</bar>
    </abc>");
    
    var query = xml.Elements().Where(e => e.Value.Contains("testing"));
    if (query.Any())
    {
        foreach (var item in query)
        {
            Console.WriteLine("{0}: {1}", item.Name, item.Value);
        }
    }
    else
    {
        Console.WriteLine("Value not found!");
    }
