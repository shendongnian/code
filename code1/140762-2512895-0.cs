    private const int maximumSingleLineTooltipLength = 20;
    private static string AddNewLinesForTooltip(string text)
    {
        if (text.Length < maximumSingleLineTooltipLength)
            return text;
        int lineLength = (int)Math.Sqrt((double)text.Length) * 2;
        StringBuilder sb = new StringBuilder();
        int currentLinePosition = 0;
        for (int textIndex = 0; textIndex < text.Length; textIndex++)
        {
            // If we have reached the target line length and the next 
            // character is whitespace then begin a new line.
            if (currentLinePosition >= lineLength && 
                  char.IsWhiteSpace(text[textIndex]))
            {
                sb.Append(Environment.NewLine);
                currentLinePosition = 0;
            }
            // If we have just started a new line, skip all the whitespace.
            if (currentLinePosition == 0)
                while (textIndex < text.Length && char.IsWhiteSpace(text[textIndex]))
                    textIndex++;
            // Append the next character.
            if (textIndex < text.Length)
                sb.Append(text[textIndex]);
            currentLinePosition++;
        }
        return sb.ToString();
    }
