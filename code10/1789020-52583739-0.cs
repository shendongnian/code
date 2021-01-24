    public void PrintPdf()
    {
        var doc = PdfDocument.Load("c:\test.pdf");
        var printDoc = new PdfPrintDocument(doc);
        PrintController printController = new StandardPrintController();
        printDoc.PrintController = printController;
        printDoc.Print(); // Print PDF document
    }
