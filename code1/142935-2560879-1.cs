    var xml = XElement.Parse(@"<abc>
      <foo>data testing</foo>
      <foo>test data</foo>
      <bar>data value</bar>
    </abc>");
    // or to load from a file use this
    // var xml = XElement.Load("sample.xml");
    
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
