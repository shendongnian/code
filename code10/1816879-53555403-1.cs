    var result = (string)xdoc.Descendants("member")
                             .FirstOrDefault(x => (string)x.Element("name") == "responseCode")
                             ?.Element("value");
		
		var info = xdoc.Descendants("CstmrPmtStsRpt")
       .Descendants("OrgnlGrpInfAndSts")
       .Descendants("StsRsnInf")                                       
       .SelectMany(r=> r.Descendants("AddtlInf")).ToList();
       Console.WriteLine(info.Count); // prints 3.
