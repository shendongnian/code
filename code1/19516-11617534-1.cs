	/// <summary>
	/// Parse a line whose values may include newline symbols or CR/LF
	/// </summary>
	/// <param name="sr"></param>
	/// <returns></returns>
	public static string[] ParseMultiLine(StreamReader sr, char delimiter, char text_qualifier)
	{
		StringBuilder sb = new StringBuilder();
		string[] array = null;
		while (!sr.EndOfStream) {
			// Read in a line
			sb.Append(sr.ReadLine());
			// Does it parse?
			string s = sb.ToString();
			if (TryParseCSVLine(s, delimiter, text_qualifier, out array)) {
				return array;
			}
		}
		// Fails to parse - return the best array we were able to get
		return array;
	}
