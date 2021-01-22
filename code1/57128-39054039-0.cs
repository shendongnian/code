    private static string RemoveAccents(string s)
    {
        s = s.Normalize(NormalizationForm.FormD);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(s[i]) != UnicodeCategory.NonSpacingMark) sb.Append(s[i]);
        }
        return sb.ToString();
    }
