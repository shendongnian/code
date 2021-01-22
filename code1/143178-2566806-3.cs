    string input = "ŠĐĆŽ šđčćž";
    string decomposed = input.Normalize(NormalizationForm.FormD);
    char[] filtered = decomposed
        .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
        .ToArray();
    string newString = new String(filtered);
