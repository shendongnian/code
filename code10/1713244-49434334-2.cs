    public static byte[] GetEmbeddedFileData(string pdfFileName, string embeddedFileName)
    {
        byte[] attachedFileBytes = null;
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
                            int n = namesArray.Size;
                            for (int i = 0; i < n; i++)
                            {
                                i++;
                                var fileArray = namesArray.GetAsDict(i);
                                var file = fileArray.GetAsDict(iTextSharp.text.pdf.PdfName.EF);
                                foreach (iTextSharp.text.pdf.PdfName key in file.Keys)
                                {
                                    string attachedFileName = fileArray.GetAsString(key).ToString();
                                    if (attachedFileName == embeddedFileName)
                                    {
                                        var stream = (iTextSharp.text.pdf.PRStream)iTextSharp.text.pdf.PdfReader.GetPdfObject(file.GetAsIndirectObject(key));
                                        attachedFileBytes = iTextSharp.text.pdf.PdfReader.GetStreamBytes(stream);
                                        break;
                                    }
                                }
                                if (attachedFileBytes != null) break;
                            }
                        }
                    }
                }
            }
            reader.Close();
        }
        return attachedFileBytes;
    }
