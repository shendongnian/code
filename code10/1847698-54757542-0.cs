    public static int CustomComparison(string x, string y)
    {
    	var xIndexes = StringToIndexes(x);
    	var yIndexes = StringToIndexes(y);
    
    	for (int i = 0; i < 4; i++)
    	{
    		if (xIndexes[i] < yIndexes[i])
    		{
    			return -1;
    		}
    		if (xIndexes[i] > yIndexes[i])
    		{
    			return 1;
    		}
    	}
    
    	return 0;
    }
    
    private static int[] StringToIndexes(string input) {
    	var match = Regex.Match(input, @"^(\d+)\.(\d+)([a-z]+)?(?:\(([ivx]+)\))?$");
    	if (!match.Success)
    	{
    		return new[] { 0, 0, 0, 0 };
    	}
    	return new[] {
    		int.Parse(match.Groups[1].Value),
    		int.Parse(match.Groups[2].Value),
    		AlphabeticToInteger(match.Groups[3].Value),
    		RomanToInteger(match.Groups[4].Value),
    	};
    }
    private static int AlphabeticToInteger(string alpha)
    {
    	return alpha.Aggregate(0, (n, c) => n * 26 + (int)(c - 'a' + 1));
    }
    private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
    	{
    		{'i', 1},
    		{'v', 5},
    		{'x', 10},
    	};
    
    public static int RomanToInteger(string roman)
    {
    	int number = 0;
    	for (int i = 0; i < roman.Length; i++)
    	{
    		if (i + 1 < roman.Length && RomanMap[roman[i]] < RomanMap[roman[i + 1]])
    		{
    			number -= RomanMap[roman[i]];
    		}
    		else
    		{
    			number += RomanMap[roman[i]];
    		}
    	}
    	return number;
    }
