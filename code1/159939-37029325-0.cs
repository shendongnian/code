    public string ReadPdfFile(object Filename)
            {
                PdfReader reader = new PdfReader((string)Filename);
                string strText = string.Empty;
    
                for (int page = 1; page <= reader.NumberOfPages; page++)
                {
                    ITextExtractionStrategy its = new iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy();
                    PdfReader reader = new PdfReader((string)Filename);
                    String s = PdfTextExtractor.GetTextFromPage(reader, page, its);
    
                    s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    strText = strText + s;
                    reader.Close();
                }
                return strText;
            }
