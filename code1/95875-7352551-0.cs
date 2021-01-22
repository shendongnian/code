    static void ExtractAllImages()
    {
    	string path = "";
    	using (PdfDocument pdf = new PdfDocument(path))
    	{
    		for (int i = 0; i < pdf.Images.Count; i++)
    		{
    			string imageName = string.Format("image{0}", i);
    			string imagePath = pdf.Images[i].Save(imageName);
    		}
    	}
    }
