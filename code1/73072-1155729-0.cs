	public static string GetCampaignName(string xml, string accountName, string rcName)
	{
		return XDocument.Parse(xml).Descendants("Account")
			.Where(a => string.Equals(a.Attribute("name").Value,accountName)).Descendants("Campaign")
			.Where(c => c.Descendants("RemoteCampaign").Select(rc => rc.Value).Contains(rcName))
			.First().Attribute("name").Value;
	}
