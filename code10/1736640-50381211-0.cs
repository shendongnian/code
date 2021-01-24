    private List<string> GetTypeFromVariable(CommodityList commodity, string platform)
    {
    	var yrLastDigit = DateTime.Now.Year % 10;
    	
    	var commodityElement = _doc.Descendants("Commodity")
    		.Where(x => x.Attribute("name")?.Value.Equals(commodity.ToString(), StringComparison.InvariantCultureIgnoreCase) ?? false)
    		.Single();
    
    	var symbol = commodityElement.Descendants("Platform")
    		.Where(x => x.Attribute("name")?.Value.Equals(platform, StringComparison.InvariantCultureIgnoreCase) ?? false)
    		.Single()
    		.Attribute("value").Value;
    
    	return commodityElement
    		.Descendants("ContractMonths").Elements("Month")
    			.Select(v => symbol + " " + SymbolHelpers.GetSymbolContractMonthLetter(v.Attribute("value")?.Value) + yrLastDigit + " Comdty")
    			.ToList();
    }
