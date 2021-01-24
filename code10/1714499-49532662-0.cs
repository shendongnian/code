    [Test]
    public void ExtractText易城数据运营商报告()
    {
        StreamUtil.AddToResourceSearch(System.Reflection.Assembly.Load("iTextAsian"));
        StreamUtil.AddToResourceSearch(System.Reflection.Assembly.Load("iTextAsianCmaps"));
        Console.Out.Write("Text Extraction - 易城数据运营商报告.pdf\n\n");
        var pdfReader = new PdfReader(@"d:\Issues\stackoverflow\Extract PDF content failed using iTextSharp because of special fonts\易城数据运营商报告.pdf");
        var pageText = PdfTextExtractor.GetTextFromPage(pdfReader, 1, new SimpleTextExtractionStrategy());
        Console.Out.Write("Content: {0}", pageText);
    }
