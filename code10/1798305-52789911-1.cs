    private static readonly Random Random = new Random();
	public static string RandomString(int length)
	{
	    const string chars = "abcde";
		return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
	}
----------
    static void Man(string[] args)
    {
       Console.WriteLine(RandomString(100));
    }
