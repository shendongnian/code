    private string removeNestedWhitespaces(char[] st)
    {
        StringBuilder sb = new StringBuilder();
        int indx = 0, length = st.Length;
        while (indx < length)
        {
            sb.Append(st[indx]);
            indx++;
            while (indx < length && st[indx] == ' ')
                indx++;
            if(sb.Length > 1  && sb[0] != ' ')
                sb.Append(' ');
        }
        return sb.ToString();
    }
