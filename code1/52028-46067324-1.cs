    public static void MergePdf(Stream outputPdfStream, IEnumerable<string> pdfFilePaths)
    {
        using (var document = new Document())
        using (var pdfCopy = new PdfCopy(document, outputPdfStream))
        {
            pdfCopy.CloseStream = false;
            try
            {
                document.Open();
                foreach (var pdfFilePath in pdfFilePaths)
                {
                    using (var pdfReader = new PdfReader(pdfFilePath))
                    {
                        pdfCopy.AddDocument(pdfReader);
                        pdfReader.Close();
                    }
                }
            }
            finally
            {
                document?.Close();
            }
        }
    }
