    public List<string> ProcessPage(MyInfoClass file, string find)
    {
        var pdfDocument = new Document(file.PdfFilePath);
        foreach (Page page in pdfDocument.Pages)
        {
            var textAbsorber = new TextAbsorber {
                ExtractionOptions = {
                    FormattingMode = TextExtractionOptions.TextFormattingMode.Pure
                }
            };
            page.Accept(textAbsorber);
            var ext = textAbsorber.Text;
            var exts = ext.Replace("\n", "").Split('\r').ToList();
            if (ext.Contains(find))
                return exts;
        }
        return null;
    }
