    public Sample Split(string columnValue)
    {
    	var regex = new Regex(@"(?<min>\d+-)?(?<max>\d+)(?<unit>[\/a-zA-Z]+)\s?(\((?<description>(.+))\))?",RegexOptions.Compiled);
    	var match = regex.Match(columnValue);
    	if(match.Success)
    	{
    		return new Sample
    		{
    			Min = match.Groups["min"].Value,
    			Max = match.Groups["max"].Value,
    			Unit = match.Groups["unit"].Value,
    			Description = match.Groups["description"].Value
    		};
    	}
    	return default;
    }
    
    public class Sample
    {
    	public string Min{get;set;}
    	public string Max{get;set;}
    	public string Unit{get;set;}
    	public string Description{get;set;}
    }
    	
