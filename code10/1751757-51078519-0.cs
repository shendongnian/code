        internal void SaveImageAsPdf(string imageFileName, string pdfFileName, int width = 600)
        {
            using (var document = new PdfDocument())
            {
                PdfPage page = document.AddPage();
                using (XImage image = XImage.FromFile(imageFileName))
                {
                    var height = (int)(((double)width / (double)image.PixelWidth) * image.PixelHeight);
                    page.Width = width;
                    page.Height = height;
                    XGraphics graphics = XGraphics.FromPdfPage(page);
                    graphics.DrawImage(image, 0, 0, width, height);                
                }
                document.Save(pdfFileName);
            }
        }
