	protected internal static readonly char[] CHARS = " AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789,./<>?:;\'\"[]{}\\|`~!@#$%^&*()-_=+".ToCharArray();
	
	public static string Encode(string textToEncode)
	{
		var map = CHARS.Select((c, n) => new { c, v = $"{n}-" }).ToDictionary(x => x.c, x => x.v);
		return String.Join("", textToEncode.Select(x => map[x]));
	}
