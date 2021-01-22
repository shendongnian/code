    public static void AddTiff(Document pdfDocument, Rectangle pdfPageSize, String tiffPath)
    {
        RandomAccessFileOrArray ra = new RandomAccessFileOrArray(tiffPath);
        int pageCount = TiffImage.GetNumberOfPages(ra);
        for (int i = 1; i <= pageCount; i++) 
        {
            Image img = TiffImage.GetTiffImage(ra, i);
            if (img.ScaledWidth > pdfPageSize.Width || img.ScaledHeight > pdfPageSize.Height)
            {
                if (img.DpiX != 0 && img.DpiY != 0 && img.DpiX != img.DpiY)
                {
                    img.ScalePercent(100f);
                    float percentX = (pdfPageSize.Width * 100) / img.ScaledWidth;
                    float percentY = (pdfPageSize.Height * 100) / img.ScaledHeight;
                    img.ScalePercent(percentX, percentY);
                    img.WidthPercentage = 0;
                }
                else
                {
                    img.ScaleToFit(pdfPageSize.Width, pdfPageSize.Height);
                }
            }
            Rectangle pageRect = new Rectangle(0, 0, img.ScaledWidth, img.ScaledHeight);
            pdfDocument.SetPageSize(pageRect);
            pdfDocument.SetMargins(0, 0, 0, 0);
            pdfDocument.NewPage();
            pdfDocument.Add(img);
        }
    }
