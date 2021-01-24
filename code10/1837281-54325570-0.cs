    public static IEnumerable<string> SplitAndRemoveQuotes(this string string)
    {
        // TODO: handle null string
        var splitValues = string.Split(',');
        foreach(string splitValue in splitValues)
        {
             // if you are certain every split value starts and ends with string quote
             // TODO: throw exception if not start/end with string quote?
             yield return splitValue.SubString(1, splitValue.Length-2);
        }
    }
