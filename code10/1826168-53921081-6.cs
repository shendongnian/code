    var root = XElement.Parse(strXml);
    var policies = new List<Policy>();
    foreach(var item in root.Descendants("Policy"))
    {
    	policies.Add(new Policy
    	{
    	 PolNumber= item.Element("PolNumber").Value,
    	 FirstName = item.Element("FirstName").Value,
    	 LastName = item.Element("LastName").Value,
    	 BirthDate = item.Element("BirthDate").Value,
    	  MailType = item.Element("MailType").Value
    	});
    }
