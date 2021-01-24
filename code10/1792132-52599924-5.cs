    /// <summary>
    /// Merge PDF's in a single PDF file.
    /// Source: https://stackoverflow.com/a/26883360/4092887
    /// </summary>
    /// <param name="fileNames">List with (filepath & filename) of PDF temp files.</param>
    /// <param name="targetPdf">Path and filename of the PDF unified file.</param>
    /// <returns>bool</returns>
    public bool MergePDFs(IEnumerable<string> fileNames, string targetPdf)
    {
        bool merged = true;
    
        try
        {
            using (FileStream stream = new FileStream(targetPdf, FileMode.Create))
            {
                Document document = new Document();
                PdfCopy pdf = new PdfCopy(document, stream);
                PdfReader reader = null;
                try
                {
                    document.Open();
                    foreach (string file in fileNames)
                    {
                        reader = new PdfReader(file);
                        pdf.AddDocument(reader);
                        reader.Close();
                    }
                }
                catch (Exception)
                {
                    merged = false;
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    if (document != null)
                    {
                        document.Close();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Log error in the log file - omitted here for clarity's sake.
            MessageBox.Show("An error ocurred at merginf the PDF files: " + SALTO_DE_LINEA +
                "Check the application log file for more details", TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    
        return merged;
    }
