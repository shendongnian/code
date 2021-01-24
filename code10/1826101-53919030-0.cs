    public IEnumerable<string> GenerateScheduler(int totalHours,int remainingHours,string replacementString)
    {
    	var numberOfPlaces = replacementString.Count(x => x == '?');
    	var minValue = remainingHours;
    	var maxValue = remainingHours * Math.Pow(10,numberOfPlaces-1);
    	var combinations = Enumerable.Range(remainingHours,(int)maxValue)
    			.Where(x=> SumOfDigit(x) == remainingHours).Select(x=>x.ToString().PadLeft(numberOfPlaces,'0').ToCharArray());
    	
    	foreach(var item in combinations)
    	{
    	    var i = 0;
    		yield return Regex.Replace(replacementString, "[?]", (m) => {return item[i++].ToString(); });
    	}
    }
    
    double SumOfDigit(int value)
    {
    	int sum = 0;
    	while (value != 0)
    	{
        	int remainder;
        	value = Math.DivRem(value, 10, out remainder);
        	sum += remainder;
    	}
    	return sum;
    }
