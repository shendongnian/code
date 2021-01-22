    static void GetImagesFromPdfAsBitmaps()
    {
    	string pathToPdf = "";
    	using (PdfDocument pdf = new PdfDocument(pathToPdf))
    	{
    		for (int i = 0; i < pdf.Images.Count; i++)
    		{
    			using (MemoryStream ms = new MemoryStream())
    			{
    				pdf.Images[i].Save(ms);
    
    				// don't forget to rewind stream
    				ms.Position = 0;
    
    				System.Drawing.Image bitmap = System.Drawing.Bitmap.FromStream(ms);
    				// ... use the bitmap and then dispose it
    				bitmap.Dispose();
    			}
    		}
    	}
    }
