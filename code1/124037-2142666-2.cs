    XElement xml = new XElement("quotes",
    	new XElement("quote", "Quote #1"),
    	new XElement("quote", "Quote #2"),
    	new XElement("quote", "Quote #3"),
    	new XElement("quote", "Quote #4"),
    	new XElement("quote", "Quote #5")
    );
    //XElement xml = XElement.Load("filename"); // use file instead of above
    var randomQuote = xml.Elements()
    					 .OrderBy(r => System.Guid.NewGuid())
    					 .Select(item => item.Value)
    					 .First();
    
    Console.WriteLine(randomQuote);
