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
        }
        return sb.ToString();
    }
