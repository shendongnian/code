    public string Parse(string input)
	{
		char[] arrResult = new char[input.Length*2];
		int i = 0;
		Array.ForEach<char>(input.ToCharArray(), delegate(char c)
		                                         	{
		                                         		arrResult[i++] = '/';
		                                         		arrResult[i++] = c;
		                                         	});
		return new string(arrResult);
	}
