    private string ReplaceWithExceptions(string source, char charToReplace, 
        char replacementChar, char exceptionChar)
    {
        bool ignoreReplacementChar = false;
        char[] sourceArray = source.ToCharArray();
        for (int i = 0; i < sourceArray.Length; i++)
        {
            if (sourceArray[i] == exceptionChar)
            {
                ignoreReplacementChar = !ignoreReplacementChar;
            }
            else
            {
                if (!ignoreReplacementChar)
                {
                    if (sourceArray[i] == charToReplace)
                    {
                        sourceArray[i] = replacementChar;
                    }
                }
            }
        }
        return new string(sourceArray);
    }
