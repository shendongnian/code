    	public string AddOne (string text)
		{
			int parsed = int.Parse(text);
			string formatString = "{0:D" + text.Length + "}";
			return string.Format(formatString, parsed + 1);
		}
