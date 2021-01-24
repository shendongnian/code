    public static Version TryParseVersion(this string versionString)
	{
		if (string.IsNullOrEmpty(versionString))
			return null;
		String[] tokens = versionString.Split('.');
		if (tokens.Length < 2 || !tokens.All(t => t.All(char.IsDigit)))
			return null;
		if (tokens.Length > 4)
		{
			int maxVersionLength = tokens.Skip(4).Max(t => t.Length);
			string normalizedRest = string.Concat(tokens.Skip(4).Select(t => t.PadLeft(maxVersionLength, '0')));
			tokens[3] = $"{tokens[3].PadLeft(maxVersionLength, '0')}{normalizedRest}";
			Array.Resize(ref tokens, 4);
		}
		versionString = string.Join(".", tokens);
		bool valid = Version.TryParse(versionString, out Version v);
		return valid ? v : null;
	}
