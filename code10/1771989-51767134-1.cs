	public static int solution(string S)
	{
		return
			S
				.Split("1234567890".ToCharArray()) // split on invalid characters
				.Where(x => x.Any(y => char.IsUpper(y))) // keep only those portions containing an uppercase char
				.Select(x => x.Length) // get the length of each string
				.Max(); // find the longest
	}
