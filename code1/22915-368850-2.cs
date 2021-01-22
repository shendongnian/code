    static string RemoveDiacritics(string sIn)
    {
      string sFormD = sIn.Normalize(NormalizationForm.FormD);
      StringBuilder sb = new StringBuilder();
    
      foreach (char ch in sFormD)
      {
        UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
        if (uc != UnicodeCategory.NonSpacingMark)
        {
          sb.Append(ch);
        }
      }
    
      return (sb.ToString().Normalize(NormalizationForm.FormC));
    }
