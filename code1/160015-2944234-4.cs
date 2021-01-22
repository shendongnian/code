    public static int ToInt(string s)
	{
		bool isNegative = false, gotAnyDigit = false;
		int result = 0;
		foreach (var ch in s ?? "")
		{
			if(ch == '-' && !gotAnyDigit)
			{
				isNegative = true;
			}
			else if(char.IsDigit(ch))
			{
				var digit = ch - '0';
				result = result*10 + digit;
				gotAnyDigit = true;
			}
			else
			{
				throw new ArgumentException("Not a number");
			}
		}
		if (!gotAnyDigit)
			throw new ArgumentException("Not a number");
		return isNegative ? -result : result;
	}
