    var validParty = xElement.Descendants("Party")
    							.Elements().Where(x => x.Name == "FullName")
    							.Ancestors("Party")
    							.Elements().Where(x => x.Name == "PartyTypeCode")
    							.Ancestors("Party");
     var partyElements = from party in validParty 
    			select new
    			{
    				Name = party.Attribute("id").Value,
    				PartyTypeCode = party.Element("PartyTypeCode").Value,
    				FullName = party.Element("FullName").Value,
    				GovtID = party.Element("GovtID").Value,
    			}; 
 
