    static void searchForText(string path, string text)
    {
        using (PdfDocument pdf = new PdfDocument(path))
        {
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                string pageText = pdf.Pages[i].GetText();
    			int index = pageText.IndexOf(text, 0, StringComparison.CurrentCultureIgnoreCase);
    			if (index != -1)
    				Console.WriteLine("'{0}' found on page {1}", text, i);
            }
        }
    }
