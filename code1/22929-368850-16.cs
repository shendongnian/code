    static string RemoveDiacritics(string text)
    {
      string formD = text.Normalize(NormalizationForm.FormD);
      StringBuilder sb = new StringBuilder();
    
      foreach (char ch in formD)
      {
        UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
        if (uc != UnicodeCategory.NonSpacingMark)
        {
          sb.Append(ch);
        }
      }
    
      return sb.ToString().Normalize(NormalizationForm.FormC);
    }
