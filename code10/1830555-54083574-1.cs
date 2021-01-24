	public static bool IsPalindrome2(string str)
	{
		var isPalindrome = true;
		for (int i=0; i<str.Length ; i++)
		{
			if ( str[i] != str[str.Length -i -1])
			{
				isPalindrome = false;
				break;
			}
		}
		
		return isPalindrome;
	}
