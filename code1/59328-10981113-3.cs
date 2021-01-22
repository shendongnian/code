    /// <summary>
    /// Converts the given decimal number to the numeral system with the
    /// specified radix (in the range [2, 36]).
    /// </summary>
    /// <param name="decimalNumber">The number to convert.</param>
    /// <param name="radix">The radix of the destination numeral system (in the range [2, 36]).</param>
    /// <returns></returns>
    public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
    {
    	const int BitsInLong = 64;
    	const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    	if (radix < 2 || radix > Digits.Length)
    		throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());
    
    	if (decimalNumber == 0)
    		return "0";
    
    	int index = BitsInLong - 1;
    	long currentNumber = Math.Abs(decimalNumber);
    	char[] charArray = new char[BitsInLong];
    
    	while (currentNumber != 0)
    	{
    		int remainder = (int)(currentNumber % radix);
    		charArray[index--] = Digits[remainder];
    		currentNumber = currentNumber / radix;
    	}
    
    	string result = new String(charArray, index + 1, BitsInLong - index - 1);
    	if (decimalNumber < 0)
    	{
    		result = "-" + result;
    	}
    
    	return result;
    }
