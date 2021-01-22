	string Truncate(double value, int precision)
	{
		if (precision < 0)
		{
			throw new ArgumentOutOfRangeException("Precision cannot be less than zero");
		}
		
		string result = value.ToString();
		
		int dot = result.IndexOf('.');
		if (dot < 0)
		{
			return result;
		}
		
		int newLength = dot + precision + 1;
		
		if (newLength == dot + 1)
		{
			newLength--;
		}
		
		if (newLength > result.Length)
		{
			newLength = result.Length;
		}
		
		return result.Substring(0, newLength);
	}
