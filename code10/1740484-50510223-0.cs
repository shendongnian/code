    public static string MergePDFs(List<string> fileNames, ref string targetPdf)
    {
        string merged = "";
        using (FileStream stream = new FileStream(targetPdf, FileMode.Create))
        {
            Document document = new Document();
            PdfCopy pdf = new PdfCopy(document, stream);
            PdfReader reader = null;
            document.Open();
            foreach (var file in fileNames)
            {
                reader = new PdfReader(file);
                pdf.AddDocument(reader);
                reader.Close();
            }
            document.Close();
        }
        return merged;
    }
