    public byte[] ()
    {
        PDFFactory pdf_1 = new PDFFactory();
        PDFFactory pdf_2 = new PDFFactory();
        List<byte[]> sourceFiles = new List<byte[]>();
        sourceFiles.Add(pdf_1.GetPDFBytes);
        sourceFiles.Add(pdf_2.GetPDFBytes);
    
        PDFFactory pdfFinal = new PDFFactory();
        for (int fileCounter = 0; fileCounter <= sourceFiles.Count - 1; fileCounter += 1)
        {
            PdfReader reader2 = new PdfReader(sourceFiles[fileCounter]);
            int numberOfPages = reader2.NumberOfPages;
    
            for (int currentPageIndex = 1; currentPageIndex <= numberOfPages; currentPageIndex++)
            {
                // Determine page size for the current page
                pdfFinal.PDFDocument.SetPageSize(reader2.GetPageSizeWithRotation(currentPageIndex));
    
                // Create page
                pdfFinal.PDFDocument.NewPage();
                PdfImportedPage importedPage = pdfFinal.PDFWriter.GetImportedPage(reader2, currentPageIndex);
    
                // Determine page orientation
                int pageOrientation = reader2.GetPageRotation(currentPageIndex);
                if ((pageOrientation == 90) || (pageOrientation == 270))
                    pdfFinal.PDFWriter.DirectContent.AddTemplate(importedPage, 0, -1.0F, 1.0F, 0, 0, reader2.GetPageSizeWithRotation(currentPageIndex).Height);
                else
                    pdfFinal.PDFWriter.DirectContent.AddTemplate(importedPage, 1.0F, 0, 0, 1.0F, 0, 0);
            }
        }
    
        pdfFinal.closeDocument();
        return pdfFinal.PDFBytes;
    }
