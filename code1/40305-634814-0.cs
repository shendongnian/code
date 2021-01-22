    public static IEnumerable<string> Split(this string input, 
                                            string separator,
                                            char escapeCharacter)
    {
        int startOfSegment = 0;
        int index = 0;
        while (index < input.Length)
        {
            index = input.IndexOf(separator, index);
            if (index > 0 && input[index-1] == escapeCharacter)
            {
                index += separator.Length;
                continue;
            }
            if (index == -1)
            {
                break;
            }
            yield return input.Substring(startOfSegment, index-startOfSegment);
            index += separator.Length;
            startOfSegment = index;
        }
        yield return input.Substring(startOfSegment);
    }
