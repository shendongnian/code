    internal static MemoryStream mergePdfs(byte[] pdf1, byte[] pdf2)
    {
        MemoryStream outStream = new MemoryStream();
        using (Document document = new Document())
        using (PdfCopy copy = new PdfCopy(document, outStream))
        {
            document.Open();
            copy.AddDocument(new PdfReader(pdf1));
            copy.AddDocument(new PdfReader(pdf2));
        }
        return outStream;
    }
    
