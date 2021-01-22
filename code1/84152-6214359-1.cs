    public static string RemoveDiacritics(string value)
    {
        if (value.IsNullOrEmpty())
            return value;
        string normalized = value.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                sb.Append(c);
        }
        Encoding nonunicode = Encoding.GetEncoding(850);
        Encoding unicode = Encoding.Unicode;
        byte[] nonunicodeBytes = Encoding.Convert(unicode, nonunicode, unicode.GetBytes(sb.ToString()));
        char[] nonunicodeChars = new char[nonunicode.GetCharCount(nonunicodeBytes, 0, nonunicodeBytes.Length)];
        nonunicode.GetChars(nonunicodeBytes, 0, nonunicodeBytes.Length, nonunicodeChars, 0);
        return new string(nonunicodeChars);
    }
