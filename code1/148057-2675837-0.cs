    public string ConvertSuperscript(string value)
    {
        string stringFormKd = value.Normalize(NormalizationForm.FormKD);
        StringBuilder stringBuilder = new StringBuilder();
    
        foreach (char character in stringFormKd)
        {
            UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(character);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(character);
            }
        }
    
        return stringBuilder.ToString().Normalize(NormalizationForm.FormKC);
    }
