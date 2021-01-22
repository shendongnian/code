	private static Dictionary<string, string> EncodeMapping()
	{
		//-- Following characters are invalid for windows file and folder names.
		//-- \/:*?"<>|
		Dictionary<string, string> dic = new Dictionary<string, string>();
		dic.Add(@"\", "Ì"); // U+OOCC
		dic.Add("/", "Í"); // U+OOCD
		dic.Add(":", "¦"); // U+00A6
		dic.Add("*", "¤"); // U+00A4
		dic.Add("?", "¿"); // U+00BF
		dic.Add(@"""", "ˮ"); // U+02EE
		dic.Add("<", "«"); // U+00AB
		dic.Add(">", "»"); // U+00BB
		dic.Add("|", "│"); // U+2502
		return dic;
	}
	public static string EncodeIoName(string name)
	{
		foreach (KeyValuePair<string, string> replace in EncodeMapping())
		{
			name = name.Replace(replace.Key, replace.Value);
		}
		return name;
	}
	public static string DecodeIoName(string name)
	{
		foreach (KeyValuePair<string, string> replace in EncodeMapping())
		{
			name = name.Replace(replace.Value, replace.Key);
		}
		return name;
	}
