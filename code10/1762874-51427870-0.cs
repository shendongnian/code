    public decimal CalculateAverage(string temps)
    {
    	decimal sum = 0m;
	    for (int i = 0; i < temps.Length; i += 8)
    	{
	    	sum += Decimal.Parse(temps.Substring(i, 4));
    	}
        return sum / (temps.Length / 8);
    }
