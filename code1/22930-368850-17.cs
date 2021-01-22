    static string RemoveDiacritics(string text)
    {
      return string.Concat( 
          text.Normalize(NormalizationForm.FormD)
          .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch)!=
                                        UnicodeCategory.NonSpacingMark)
        ).Normalize(NormalizationForm.FormC);
    }
