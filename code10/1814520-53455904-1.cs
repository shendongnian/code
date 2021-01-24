	public static string Decode(string textToDecode)
	{
		var map = CHARS.Select((c, n) => new { c, v = $"{n}-" }).ToDictionary(x => x.v, x => x.c);
		return String.Join("", textToDecode.Split(new [] { '-' }, StringSplitOptions.RemoveEmptyEntries).Select(x => map[$"{x}-"]));
	}
