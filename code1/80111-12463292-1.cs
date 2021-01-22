    StringBuilder stringBuilder = new StringBuilder();
    PdfReader pdfReader = new PdfReader(byte[] of the .pdf);
    for (int page = 1; page <= pdfReader.NumberOfPages; page++)
    {
        stringBuilder.Append(PdfTextExtractor.GetTextFromPage(pdfReader, page) + " ");
    }
