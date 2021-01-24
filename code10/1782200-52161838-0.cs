	var xml = @"<testing>
	  <test>
	  <text>test1</text>
	  </test>
	  <test>
	  <text>test2</text>
	  </test>   
	</testing>
	";
	
	var testing = XElement.Parse(xml);
	var tests = testing.XPathSelectElements("test");
	foreach (var test in tests)
	{
		var val = test.Descendants().First().Value;
        Console.WriteLine(val); // test1, test2
	}
