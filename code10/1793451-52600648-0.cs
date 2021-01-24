    var testObj = (from el in xml.DescendantsAndSelf().Elements("TestIdentification")
				   where el.Element("TestType").Value == "TESTID2" && !string.IsNullOrWhiteSpace(el.Element("TestID")?.Value)
				   select new TestClassObj { TestID = el.Element("TestID").Value })
				   .FirstOrDefault();
					   
    Console.WriteLine(testObj.TestID); // 106492
