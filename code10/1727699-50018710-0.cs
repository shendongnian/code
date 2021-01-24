    public static string RemoveDiacritics(this string @this) {
        var normalizedString = @this.Normalize(System.Text.NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();
        foreach (var c in normalizedString) {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark) {
                stringBuilder.Append(c);
            }
        }
        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
