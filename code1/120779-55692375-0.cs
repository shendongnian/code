    public static string GetCommonPrefix(IList<string> strings)
    {
        var stringsCount = strings.Count;
        if (stringsCount == 0)
            return null;
        if (stringsCount == 1)
            return strings[0];
        var sb = new System.Text.StringBuilder(strings[0]);
        for (int i = 1; i < stringsCount; i++)
        {
            var str = strings[i];
            if (sb.Length > str.Length)
                sb.Length = str.Length;
            for (int j = 0; j < sb.Length; j++)
            {
                if (sb[j] != str[j])
                {
                    sb.Length = j;
                    break;
                }
            }
        }
        return sb.ToString();
    }
