    public string AddSpacesBeforeUpperCase(string nonSpacedString)
        {
            if (string.IsNullOrEmpty(nonSpacedString))
                return string.Empty;
            StringBuilder newText = new StringBuilder(nonSpacedString.Length * 2);
            newText.Append(nonSpacedString[0]);
            for (int i = 1; i < nonSpacedString.Length; i++)
            {
                char currentChar = nonSpacedString[i];
                // If it is whitespace, we do not need to add another next to it
                if(char.IsWhiteSpace(currentChar))
                {
                    continue;
                }
                char previousChar = nonSpacedString[i - 1];
                char nextChar = i < nonSpacedString.Length - 1 ? nonSpacedString[i + 1] : nonSpacedString[i];
                if (char.IsUpper(currentChar) && !char.IsWhiteSpace(nextChar) 
                    && !(char.IsUpper(previousChar) && char.IsUpper(nextChar)))
                {
                    newText.Append(' ');
                }
                else if (i < nonSpacedString.Length)
                {
                    if (char.IsUpper(currentChar) && !char.IsWhiteSpace(nextChar) && !char.IsUpper(nextChar))
                    {
                        newText.Append(' ');
                    }
                }
                newText.Append(currentChar);
            }
            return newText.ToString();
        }
