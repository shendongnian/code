	static string GetNextColumn(string col)
	{
		char[] charArr = col.ToCharArray();
		var cur = Convert.ToChar((int) charArr[charArr.Length - 1]);
		if (cur == 'Z')
		{
			if (charArr.Length == 1)
			{
				return "AA";
			}
			else
			{
				char[] newArray = charArr.Take(charArr.Length - 1).ToArray();
				var ret = GetNextColumn(new string(newArray));
				return ret + "A";
			}
		}
		charArr[charArr.Length - 1] = Convert.ToChar((int)charArr[charArr.Length - 1] + 1);
		return new string(charArr);
	}
