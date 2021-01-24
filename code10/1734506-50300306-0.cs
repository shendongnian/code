    private static string ReadPdfFile(string fileName)
    {
        StringBuilder text = new StringBuilder();
        if (File.Exists(fileName))
        {
            PdfReader pdfReader = new PdfReader(fileName);
            ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
            string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, 1, strategy);
            //currentText = Encoding.UTF8.GetString(UTF8Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
            text.Append(currentText);
        }
        return text.ToString();
    }
