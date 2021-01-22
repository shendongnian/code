    public static string TrimWhiteSpace(this string Value)
    {
        StringBuilder sbOut = new StringBuilder();
        if (!string.IsNullOrEmpty(Value))
        {
            bool IsWhiteSpace = false;
            for (int i = 0; i < Value.Length; i++)
            {
                if (char.IsWhiteSpace(Value[i])) //Comparion with WhiteSpace
                {
                    if (!IsWhiteSpace) //Comparison with previous Char
                    {
                        sbOut.Append(Value[i]);
                        IsWhiteSpace = true;
                    }
                }
                else
                {
                    IsWhiteSpace = false;
                    sbOut.Append(Value[i]);
                }
            }
        }
        return sbOut.ToString();
    }
