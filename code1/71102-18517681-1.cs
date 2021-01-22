    public static string EnsureOnlyLetterDigitOrWhiteSpace(string input)
    {
        StringBuilder cleanedInput = null;
        for (var i = 0; i < input.Length; ++i)
        {
            var currentChar = input[i];
            var charIsValid = char.IsLetterOrDigit(currentChar) || char.IsWhiteSpace(currentChar);
            if (charIsValid)
            {
                if(cleanedInput != null)
                    cleanedInput.Append(currentChar);
            }
            else
            {
                if (cleanedInput != null) continue;
                cleanedInput = new StringBuilder();
                if (i > 0)
                    cleanedInput.Append(input.Substring(0, i));
            }
        }
        return cleanedInput == null ? input : cleanedInput.ToString();
    }
