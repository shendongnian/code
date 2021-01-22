    public static string ReplaceUrls(string input)
    {
        var result = Regex.Replace(input.ToSafeString(), TextLink.Pattern, match =>
        {
            var textLink = new TextLink(match.Value);
            return textLink.Valid ?
                string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", textLink, textLink.OriginalInput) :
                textLink.OriginalInput;
        });
        return result;
    }
