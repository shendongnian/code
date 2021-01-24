    public static int LongestSubstring(string s)
    {
        int maxLength = 0;
        bool upperCaseFound = false;
        int length = 0;
        foreach (char ch in s)
        {
            if (char.IsDigit(ch))
            {
                if (upperCaseFound && length > maxLength)
                {
                    maxLength = length;
                }
                upperCaseFound = false;
                length = 0;
                continue;
            }
            if (char.IsUpper(ch))
            {
                upperCaseFound = true;
            }
            length++;
        }
        if (upperCaseFound && length > maxLength)
        {
            maxLength = length;
        }
        return maxLength;
    }
