        public void LoadPdf(byte[] pdfBytes)
        {
            var stream = new MemoryStream(pdfBytes);
            LoadPdf(stream)
        }
        public void LoadPdf(Stream stream)
        {
            // Create PDF Document
            var pdfDocument = PdfDocument.Load(stream);
            // Load PDF Document into WinForms Control
            pdfRenderer.Load(_pdfDocument);
        }
