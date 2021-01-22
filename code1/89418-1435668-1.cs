    private static DateTime ExtractDateTime(string format)
    {
        int length = format.Length;
        for (int startIndex = 0; startIndex < length; startIndex++)
        {
            for(int subLength = length - startIndex; subLength > 0; subLength--)
            {
                string substring = format.Substring(startIndex, subLength);
                DateTime result;
                if (DateTime.TryParse(substring, out result))
                {
                    return result;
                }
            }
        }
        return DateTime.MinValue;
    }
      
