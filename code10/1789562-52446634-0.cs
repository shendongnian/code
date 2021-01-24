    public class PDFFactory
    {
        public PDFFactory()
        {
            PdfDocument = new Document(iTextSharp.text.PageSize.A4, 65, 65, 60, 60);
        }
    
        private Document _pdfDocument;
        public Document PdfDocument
        {
            get
            {
                return _pdfDocument;
            }
            set
            {
                _pdfDocument = value;
            }
        }
    
        private MemoryStream _pdfMemoryStream;
        public MemoryStream PDFMemoryStream
        {
            get
            {
                return _pdfMemoryStream;
            }
            set
            {
                _pdfMemoryStream = value;
            }
        }
    
        private string _pdfBase64;
        public string PDFBase64
        {
            get
            {
                if (this.DocumentClosed)
                    return _pdfBase64;
                else
                    return null;
            }
            set
            {
                _pdfBase64 = value;
            }
        }
    
        private byte[] _pdfBytes;
        public byte[] PDFBytes
        {
            get
            {
                if (this.DocumentClosed)
                    return _pdfBytes;
                else
                    return null;
            }
            set
            {
                _pdfBytes = value;
            }
        }
    
        public byte[] GetPDFBytes()
        {
            PDFDocument.Close();
            return PDFMemoryStream.GetBuffer();
        }
    
        public void closeDocument()
        {
            PDFDocument.Close();
            PDFBase64 = Convert.ToBase64String(this.PDFMemoryStream.GetBuffer());
            PDFBytes = this.PDFMemoryStream.GetBuffer();
        }
    }
