    string strsvresponse = "name:bob, age:22, city:Wolverhampton, state:West, Midlands, UK, country:United Kingdom";
    var result = new Dictionary<String, String>();
    var pairs = strsvresponse.Split(',');
    for (int i = pairs.Count()-1; i >= 0; i--)
    {
    	var pair = pairs[i].Split(':');
    	if (pair.Length == 2)
    	{
    		result.Add(pair[0].Trim(), pair[1].Trim());
    	}
    	else
    	{
    		pairs[i-1] = pairs[i-1] + pairs[i]; // add comma here if needed
    	}
    }
    return result;
