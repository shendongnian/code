    public static string ToJsonIdentifier(string s)
    {
        // special case, s is empty
        if (string.IsNullOrEmpty(s)) return s;
        var result = new StringBuilder();
        bool isFirst = true; // Is First (non-whitespace) Character Flag
        bool isSpace = false; // Is Whitespace Flag
        bool isUpperCase = false; // Is Uppercase Flag
        foreach(char c in s)
        {
            // filter to be letter or digit only
            if(!char.IsLetterOrDigit(c))
            {
                continue;
            }
            if(isFirst)
            {
                if (!char.IsWhiteSpace(c))
                {
                    // if first character, set to lower case
                    result.Append(char.ToLower(c));
                    isFirst = false; // no more first flag
                }
                // if WhiteSpace, ignore the character
            }
            else if(char.IsWhiteSpace(c))
            {
                isSpace = true; // set the Whitespace flag, so next char should be uppercase
            }
            else if(char.IsUpper(c))
            {
                if (!isUpperCase)
                {
                    // if previous char is lower case, set it as it is (as uppercase) 
                    result.Append(c);
                    isUpperCase = true;
                }
                else
                {
                    // if previous char is uppercase, set this to lower instead
                    result.Append(char.ToLower(c));
                    // and keep the uppercase flag on, so multiple uppercase in the row will be converted to lower, until lower case is found.
                }
            }
            else if(char.IsLower(c))
            {
                if(isSpace) // if previous char is whitespace, set char to be upper case
                {
                    isSpace = false; // no more whitespace flag
                    result.Append(char.ToUpper(c));
                    isUpperCase = true;  // set upper case flag on
                }
                else
                {
                    isUpperCase = false; // no more upper case flag
                    result.Append(c);
                }
            }
            else if(char.IsDigit(c))
            {
                // reset all flags
                isSpace = false;
                isUpperCase = false;
                result.Append(c);
            }
        }
        return result.ToString();
    }
