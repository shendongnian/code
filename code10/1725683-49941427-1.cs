        using (var pdfDoc = new PdfDocument(new PdfReader("doc.pdf")))
        {
            var outputDir = @"C:\";
            var splitter = new CustomSplitter(pdfDoc, outputDir);
            var splittedDocs = splitter.SplitByPageCount(1);
            foreach (var splittedDoc in splittedDocs)
            {
                splittedDoc.Close();
            }
        }
