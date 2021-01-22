    public static string SimplifyDateFormat(DateTimeFormatInfo DTFI)
    {
        StringBuilder SB = new StringBuilder(DTFI.ShortDatePattern.ToLower());
        SB.Replace("m y", "m/y").Replace(" 'г.'", "").Replace(" ", "").Replace("dd", "d")
        .Replace("mm", "m").Replace("yyyy", "y").Replace("yy", "y");
        if (SB[SB.Length - 1] == '.') SB.Remove(SB.Length - 1, 1);
        return SB.ToString();
    }
