    static void ExtractImagesFromPdfPageIntoFolder()
    {
    	string pathToPdf = "";
    	int pageIndex = 0;
    	string outputFolder = "";
    	using (PdfDocument pdf = new PdfDocument(pathToPdf))
    	{
    		for (int i = 0; i < pdf.Pages[pageIndex].Images.Count; i++)
    		{
    			string imageName = string.Format("image{0}", i);
    			string outputName = Path.Combine(outputFolder, imageName);
    			string savedPath = pdf.Pages[pageIndex].Images[i].Save(outputName);
    		}
    	}
    }
