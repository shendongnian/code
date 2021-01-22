       public override String ExtractText()
        {
            String outputText = "";
            try
            {
                PdfDocument inputDocument = PdfReader.Open(this._sDirectory + this._sFileName, PdfDocumentOpenMode.ReadOnly);
                foreach (PdfPage page in inputDocument.Pages)
                {
                    for (int index = 0; index < page.Contents.Elements.Count; index++)
                    {
                        PdfDictionary.PdfStream stream = page.Contents.Elements.GetDictionary(index).Stream;
                        outputText += new PDFParser().ExtractTextFromPDFBytes(stream.Value);
                    }
                }
            }
            catch (Exception e)
            {
                PDF_ParseException oEx = new PDF_ParseException(this, e);
                oEx.Log();
                oEx.ToPdf(this._sDirectoryException);
            }
            return outputText;
        }
