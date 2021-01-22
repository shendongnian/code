    private static DateTime ExtractDateTime(string format)
    {
        DateTime result= DateTime.MinValue;
        int startIndex = 0;
        for (; startIndex < format.Length; startIndex++)
        {
            if (DateTime.TryParse(_format.Substring(startIndex), out result))
            {
                break;
            }
        }
        return result;
    }
