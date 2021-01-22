	int count = xml.Elements().Count();
	var randomQuote = xml.Elements()
						 .OrderBy(i => rand.Next(0, count))
                         .Select(element => new { 
							Customer = element.Element("customer").Value,
							Quote = element.Element("text").Value
						  })
                         .First();
    
    Console.WriteLine("{0} : {1}", result.Customer, result.Quote); 
