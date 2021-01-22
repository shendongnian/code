    static void ExtractImagesFromPdfPages()
    {
    	string path = "";
    	using (PdfDocument pdf = new PdfDocument(path))
    	{
    		for (int i = 0; i < pdf.Pages.Count; i++)
    		{
    			for (int j = 0; j < pdf.Pages[i].Images.Count; j++)
    			{
    				string imageName = string.Format("page{0}-image{1}", i, j);
    				string imagePath = pdf.Pages[i].Images[j].Save(imageName);
    			}
    		}
    	}
    }
