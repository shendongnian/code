    public static void imagesToPdf(string[] images, string pdfName)
    {
    	using (PdfDocument pdf = new PdfDocument())
    	{
    		for (int i = 0; i < images.Length; i++)
    		{
    			if (i > 0)
    				pdf.AddPage();
    
    			PdfPage page = pdf.Pages[i];
    			string imagePath = images[i];
    			PdfImage pdfImage = pdf.AddImage(imagePath);
    
    			page.Width = pdfImage.Width;
    			page.Height = pdfImage.Height;
    			page.Canvas.DrawImage(pdfImage, 0, 0);
    		}
    
    		pdf.Save(pdfName);
    	}
    }
