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
	var tests = testing.XPathEvaluate("test/text/text()") as IEnumerable;
	foreach (var test in tests)
	{
		Console.WriteLine(test); // test1, test2
	}
