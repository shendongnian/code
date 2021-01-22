    public void ConvertPDFtoJPG(string filename, String dirOut)
    {
        PDFLibNet.PDFWrapper _pdfDoc = new PDFLibNet.PDFWrapper();
        _pdfDoc.LoadPDF(filename);
        for (int i = 0; i < _pdfDoc.PageCount; i++)
        {
            Image img = RenderPage(_pdfDoc, i);
            img.Save(Path.Combine(dirOut, string.Format("{0}{1}.jpg", i,DateTime.Now.ToString("mmss"))));
        }
        _pdfDoc.Dispose();
        return;
    }
    public  Image RenderPage(PDFLibNet.PDFWrapper doc, int page)
    {
        doc.CurrentPage = page + 1;
        doc.CurrentX = 0;
        doc.CurrentY = 0;
        doc.RenderPage(IntPtr.Zero);
            // create an image to draw the page into
            var buffer = new Bitmap(doc.PageWidth, doc.PageHeight);
            doc.ClientBounds = new Rectangle(0, 0, doc.PageWidth, doc.PageHeight);
            using (var g = Graphics.FromImage(buffer))
            {
                var hdc = g.GetHdc();
                try
                {
                    doc.DrawPageHDC(hdc);
                }
                finally
                {
                    g.ReleaseHdc();
                }
            }
            return buffer;
        
    }
