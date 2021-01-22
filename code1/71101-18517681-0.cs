    public static string EnsureOnlyLetterDigitOrWhiteSpace(string input)
    {
        StringBuilder res = null;
        for (var i = 0; i < input.Length; ++i)
        {
            var c = input[i];
            var ok = char.IsLetterOrDigit(c) || char.IsWhiteSpace(c);
        
            if (res == null)
            {
                if (ok)
                    continue;
        
                res = new StringBuilder();
                if (i > 0)
                    res.Append(input.Substring(0, i));
            }
        
            if (ok)
                res.Append(c);
        }
        
        return res == null ? input : res.ToString();
    }
