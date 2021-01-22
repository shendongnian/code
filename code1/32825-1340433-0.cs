    public static string[] SplitAndKeepSeparators(string value, char[] separators, StringSplitOptions splitOptions)
    {
        List<string> splitValues = new List<string>();
        int itemStart = 0;
        for (int pos = 0; pos < value.Length; pos++)
        {
            for (int sepIndex = 0; sepIndex < separators.Length; sepIndex++)
            {
                if (separators[sepIndex] == value[pos])
                {
                    // add the section of string before the separator 
                    // (unless its empty and we are discarding empty sections)
                    if (itemStart != pos || splitOptions == StringSplitOptions.None)
                    {
                        splitValues.Add(value.Substring(itemStart, pos - itemStart));
                    }
                    itemStart = pos + 1;
                    // add the separator
                    splitValues.Add(separators[sepIndex].ToString());
                    break;
                }
            }
        }
        
        // add anything after the final separator 
        // (unless its empty and we are discarding empty sections)
        if (itemStart != value.Length || splitOptions == StringSplitOptions.None)
        {
            splitValues.Add(value.Substring(itemStart, value.Length - itemStart));
        }
        return splitValues.ToArray();
    }
