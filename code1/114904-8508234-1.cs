    public static void ExtractFormattedText(string pdfFile, string textFile)
    {
    	using (PdfDocument doc = new PdfDocument(pdfFile))
    	{
    		string text = doc.GetTextWithFormatting();
    		File.WriteAllText(textFile, text);
    	}
    }
