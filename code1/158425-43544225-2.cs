        public static void ExtractPagesFromPdf(string inputFile, string outputFile, int start, int end)
        {
            PdfReader inputPdf = new PdfReader(inputFile);
            PdfDocument docIn = new PdfDocument(inputPdf);
            PdfWriter outputWriter = new PdfWriter(outputFile);
            PdfDocument docOut = new PdfDocument(outputWriter);
            // retrieve the total number of pages
            int pageCount = docIn.GetNumberOfPages();
            if (end < start || end > pageCount)
            {
                end = pageCount;
            }
            var merge = new PdfMerger(docOut);
            merge.Merge(docIn, start, end);
            merge.Close();
        }
