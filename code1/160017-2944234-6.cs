    public static int ToInt(string s)
	{
		bool isNegative = false, gotAnyDigit = false;
		int result = 0;
		foreach (var ch in s ?? "")
		{
			if(ch == '-' && !(gotAnyDigit || isNegative))
			{
				isNegative = true;
			}
			else if(char.IsDigit(ch))
			{
				result = result*10 + (ch - '0');
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
