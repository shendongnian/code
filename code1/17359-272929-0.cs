    string AddSpacesToSentence(string text)
    {
            StringBuilder newText = new StringBuilder(text.Length * 2);
            if (!string.IsNullOrEmpty(text))
            {
                newText.Append(text[0]);
                for (int i = 1; i < text.Length; i++)
                {
                    if (char.IsUpper(text[i]))
                        newText.Append(' ');
                    newText.Append(text[i]);
                }
            }
            return newText.ToString();
    }
