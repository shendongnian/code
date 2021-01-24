    string AddUnderScoresToSentence(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return "";
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]) && text[i - 1] != '_')
                    newText.Append('_');
                newText.Append(text[i]);
            }
            string result = newText.ToString();
            return result.ToLower();
        }
