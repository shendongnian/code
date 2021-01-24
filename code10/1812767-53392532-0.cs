    PdfReader formReader = new PdfReader(front_path);
    PdfReader backReader = new PdfReader(back_path);
    PdfWriter writer = new PdfWriter(merge_path);
    using (PdfDocument source = new PdfDocument(backReader))
    using (PdfDocument target = new PdfDocument(formReader, writer))
    {
        PdfFormXObject xobject = source.GetPage(1).CopyAsFormXObject(target);
        PdfPage targetFirstPage = target.GetFirstPage();
        PdfStream stream = targetFirstPage.NewContentStreamBefore();
        PdfCanvas pdfCanvas = new PdfCanvas(stream, targetFirstPage.GetResources(), target);
        Rectangle cropBox = targetFirstPage.GetCropBox();
        pdfCanvas.AddXObject(xobject, cropBox.GetX(), cropBox.GetY());
    }
