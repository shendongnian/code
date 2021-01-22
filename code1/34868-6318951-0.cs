    /// <summary>.Net 2.0's HttpUtility.HtmlEncode will not properly encode
    /// Unicode characters above 0xFF.  This may be fixed in newer 
    /// versions.</summary>
    public static string HtmlEncode(string s)
    {
        // Let .Net 2.0 get right what it gets right.
        s = HttpUtility.HtmlEncode(s);
        // Search for first non-ASCII.  Hopefully none and we can just 
        // return s.
        int num = IndexOfHighChar(s, 0);
        if (num == -1)
            return s;
        int old_num = 0;
        StringBuilder sb = new StringBuilder();
        do {
            sb.Append(s, old_num, num - old_num);
            sb.Append("&#");
            sb.Append(((int)s[num]).ToString(NumberFormatInfo.InvariantInfo));
            sb.Append(';');
            old_num = num + 1;
            num = IndexOfHighChar(s, old_num);
        } while (num != -1);
        sb.Append(s, old_num, s.Length - old_num);
        return sb.ToString();
    }
    static unsafe int IndexOfHighChar(string s, int start)
    {
        int num = s.Length - start;
        fixed (char* str = s) {
            char* chPtr = str + start;
            while (num > 0) {
                char ch = chPtr[0];
                if (ch >= 'Ā')
                    return s.Length - num;
                chPtr++;
                num--;
            }
        }
        return -1;
    }
