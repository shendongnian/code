    using (PdfReader pdfReader = new PdfReader(source))
    using (PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileStream(dest, FileMode.Create, FileAccess.Write), (char)0, true))
    {
        pdfStamper.RotateContents = false;
        PdfContentStreamEditor editor = new TextRemover();
        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
        {
            editor.EditPage(pdfStamper, i);
        }
    }
