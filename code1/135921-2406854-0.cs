    var parties = xmlDoc.Descendants("Party");
    foreach(var party in parties)
    {
    	int partyTypeCode = party.Element("PartyTypeCode").Value;
    	if(partyTypeCode == 1)
    	{
    		var person = personFactory.Build(party);
    		// do something
    	}
    	else if(partyTypeCode == 2)
    	{
    		var organization = companyFactory.Build(party);
    		// do something
    	}
    }
