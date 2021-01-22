    ...
    PdfDocument pdfDoc = PdfReader.Open(myUri.LocalPath, PdfDocumentOpenMode.Import);
    PdfDocument pdfNewDoc = new PdfDocument();
	for (int i = 0; i < pdfDoc.Pages.Count; i++)
    {
	   PdfPage page = pdfNewDoc.AddPage(pdfDoc.Pages[i]);
       XFont fontNormal = new XFont("Calibri", 10, XFontStyle.Regular);    
       XGraphics gfx = XGraphics.FromPdfPage(page);
       var xrect = new XRect(240, 395, 300, 20);
       var rect = gfx.Transformer.WorldToDefaultPage(xrect);
       var pdfrect = new PdfRectangle(rect);
	
	   //file link
	   page.AddFileLink(pdfrect, myUri.LocalPath);
       //web link
	   //page.AddWebLink(pdfrect, myUri.AbsoluteUri);
	
    
       gfx.DrawString("MyFileName", fontNormal, XBrushes.Black, xrect, XStringFormats.TopLeft);
    }
	pdfNewDoc.Save(myDestinationUri.LocalPath + "MyNewPdfFile.pdf");
	...
