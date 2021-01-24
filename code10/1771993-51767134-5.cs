	public static int solution(string S)
	{
		int result = 0;
		int tally = 0;
		bool foundUpper = false;
	
		for (int i = 0; i < S.Length; i++)
		{
			char Z = S[i];
	
			if (char.IsDigit(Z))
			{
				if (foundUpper && tally > result)
				{
					result = tally;
				}
				tally = 0;
				foundUpper = false;
			}
			else
			{
				tally++;
				foundUpper |= char.IsUpper(Z);
			}
		}
		if (foundUpper && tally > result)
		{
			result = tally;
		}
		return result;
	}
