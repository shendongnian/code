    const string PdfTableFormat = @"\(.*\)Tj";
    Regex PdfTableRegex = new Regex(PdfTableFormat, RegexOptions.Compiled);
    List<string> ExtractPdfContent(string rawPdfontent)
    {
        var matches = PdfTableRegex.Matches(rawPdfContent);
        var list = matches.Cast<Match>()
            .Select(m => m.Value
                .Substring(1) //remove leading (
                .Remove(m.Value.Length - 4) //remove trailing )Tj
                .Replace(@"\)", ")") //unencode parens
                .Replace(@"\(", "(")
                .Trim()
            )
            .ToList();
        return list;
    }
