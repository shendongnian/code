	public static string AddSpacesToSentence(string text)
	{
		if (string.IsNullOrEmpty(text))
			return "";
		StringBuilder newText = new StringBuilder(text.Length * 2);
		newText.Append(text[0]);
                for (int i = 1; i < result.Length; i++)
                {
                    if (char.IsUpper(result[i]) && !char.IsUpper(result[i - 1]))
                    {
                        newText.Append(' ');
                    }
                    else if (i < result.Length)
                    {
                        if (char.IsUpper(result[i]) && !char.IsUpper(result[i + 1]))
                            newText.Append(' ');
                    }
                    newText.Append(result[i]);
                }
		return newText.ToString();
	}
