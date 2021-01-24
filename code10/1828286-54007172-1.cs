    using (iText.Kernel.Pdf.PdfWriter writer = new iText.Kernel.Pdf.PdfWriter(outputPdfFile))
	{
		using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
		{
			iText.Layout.Document doc = new iText.Layout.Document(pdf);
			doc.Add(new iText.Layout.Element.Paragraph("Title"));
			//barcode
			iText.Barcodes.BarcodeInter25 bar = new iText.Barcodes.BarcodeInter25(pdf);
			bar.SetCode("0600123456");
			iText.Kernel.Pdf.Canvas.PdfCanvas canvas = new iText.Kernel.Pdf.Canvas.PdfCanvas(pdf.GetFirstPage());
			//bar.PlaceBarcode(canvas, iText.Kernel.Colors.ColorConstants.BLUE, iText.Kernel.Colors.ColorConstants.GREEN);
			
			iText.Kernel.Pdf.Xobject.PdfFormXObject barcodeFormXObject = bar.CreateFormXObject(iText.Kernel.Colors.ColorConstants.BLACK, iText.Kernel.Colors.ColorConstants.BLACK, pdf);
			float scale = 1;
			float x = 450;
			float y = 700;
			canvas.AddXObject(barcodeFormXObject, scale, 0, 0, scale, x, y);
		}
	}
