    //Merging existing PDFs using DynamicPDF Merger for .NET product.
    MergeDocument mergeDocument = new MergeDocument();
    mergeDocument.Append(@"D:\temporary\DocumentB.pdf");
    mergeDocument.Append(@"D:\temporary\DocumentC.pdf");
    mergeDocument.Append(@"D:\temporary\DocumentD.pdf");
     
    //Draw the merged output into byte array or save it to disk (by specifying the file path).
    byte[] byteData = mergeDocument.Draw();
     
    //Convert the merged PDF into PMG image format using DynamicPDF Rasterizer for .NET product.
    InputPdf pdfData = new InputPdf(byteData);
    PdfRasterizer rastObj = new PdfRasterizer(pdfData);
    rastObj.Draw(@"C:\temp\MyImage.png", ImageFormat.Png, ImageSize.Dpi150);
