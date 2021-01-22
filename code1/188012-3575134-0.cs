    static void Main(string[] args)
    {
    	Console.WriteLine(Base16(135.34375, 10));
    	Console.ReadLine();
    }
    
    private static string Base16(double number, int fractionalDigits)
    {
    	return Base(number, fractionalDigits, new char[]{
    		'0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
    		'A', 'B', 'C', 'D', 'E', 'F' });
    }
    
    private static string Base(double number, int fractionalDigits, params char[] characters)
    {
    	int radix = characters.Length;
    	StringBuilder sb = new StringBuilder();
    
    	// The 'whole' part of the number.
    	long whole = (long)Math.Floor(number);
    	while (whole > 1)
    	{
    		sb.Insert(0, characters[whole % radix]);
    		whole = whole / radix;
    	}
    
    	// The fractional part of the number.
    	double remainder = number % 1;
    	if (remainder > Double.Epsilon || remainder < -Double.Epsilon)
    	{
    		sb.Append('.');
    
    		double nv;
    		for (int i = 0; i < fractionalDigits; i++)
    		{
    			nv = remainder * radix;
    			if (remainder < Double.Epsilon && remainder > -Double.Epsilon)
    				break;
    			sb.Append(characters[(int)Math.Floor(nv)]);
    			remainder = nv % 1;
    		}
    	}
    
    	return sb.ToString();
    }
