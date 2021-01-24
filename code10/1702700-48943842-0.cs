    string testString = "Hello World  !   ";
    StringBuilder resultBuilder = new StringBuilder();
    int charCount = 0;
    foreach(char character in testString)
    {
        if(Char.IsWhiteSpace(character))
        {
            charCount++;
        }
        else
        {
            if(charCount > 0)
            {
                resultBuilder.Append(charCount);
                charCount = 0;
            }
            resultBuilder.Append(character);
        }
    }
    if (charCount > 0)
    {
        resultBuilder.Append(charCount);
        charCount = 0;
    }
    testString = resultBuilder.ToString();
