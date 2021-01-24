    public static string[] ListEmbeddedFileNames(string pdfFileName)
    {
        string[] fileNames = new string[0];
        var reader = new iTextSharp.text.pdf.PdfReader(pdfFileName);
        if (reader != null)
        {
            var root = reader.Catalog;
            if (root != null)
            {
                var names = root.GetAsDict(iTextSharp.text.pdf.PdfName.NAMES);
                if (names != null)
                {
                    var embeddedFiles = names.GetAsDict(iTextSharp.text.pdf.PdfName.EMBEDDEDFILES);
                    if (embeddedFiles != null)
                    {
                        var namesArray = embeddedFiles.GetAsArray(iTextSharp.text.pdf.PdfName.NAMES);
                        if (namesArray != null)
                        {
                            int n = namesArray.Size / 2; // I don't understand why I have to divide by 2
                            fileNames = new string[n];
                            for (int i = 0; i < n; i++) fileNames[i] = namesArray[2 * i].ToString();
                        }
                    }
                }
            }
            reader.Close();
        }
        return fileNames;
    }
