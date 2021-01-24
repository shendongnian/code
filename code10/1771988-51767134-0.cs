	public static int solution(string S)
	{
		return
			S
				.Split("1234567890".ToCharArray())
				.Where(x => x.Any(y => char.IsUpper(y)))
				.Select(x => x.Length)
				.Max();
	}
