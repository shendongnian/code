    public static class StupidExtensions
    {
    	public static IEnumerable<int> Digits(int input)
    	{
    		do yield return input % 10; while ((input /= 10) > 0);
    	}
    
        public static IEnumerable<int> WhereDigit(this IEnumerable<int> source, int digit) 
                  => source.Where(x => Digits(x).Contains(digit));
    }
