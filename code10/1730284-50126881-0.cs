    private Dictionary<int, Dictionary<string, double>> openNormalization()
    {
    	var lines = File.ReadLines("normalization.txt");
    
    	return lines
    	    .Select(line => line.Split(','))
    		.GroupBy(item => Convert.ToInt32(item[0]))
    		.ToDictionary(groupValues => groupValues.Key, groupValues => groupValues.ToDictionary(item => item[1], item => Convert.ToDouble(item[2])));
    }
