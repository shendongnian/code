	void Main()
	{
		Console.WriteLine(GenerateCode(CodeLength));
	}
	
	private const int CodeLength = 10;
	// since Random does not make any guarantees of thread-safety, use different Random instances per thread
	private static readonly ThreadLocal<Random> _random = new ThreadLocal<Random>(() => new Random());
	
	// Define other methods and classes here
	private static string GenerateCode(int numberOfCharsToGenerate)
	{
		char[] chars = "0123456789".ToCharArray();
	
		var sb = new StringBuilder();
		for (int i = 0; i < numberOfCharsToGenerate; i++)
		{
			int num = _random.Value.Next(0, chars.Length);
			sb.Append(chars[num]);
		}
		return sb.ToString();
	}
