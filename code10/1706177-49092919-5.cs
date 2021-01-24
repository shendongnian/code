    private void button1_Click(object sender, EventArgs e)
    {
        Bitmap screenCapture = PrintControlFromScreen(this.pictureBox1, true, 300, false, InterpolationMode.Bicubic);
        PrintDocument PrintDoc = new PrintDocument();
        PrintDoc.DocumentName = "ScreenShot";
        PrintDoc.DefaultPageSettings.PrinterResolution = new PrinterResolution() { X = 300, Y = 300 };
        PrintDoc.DefaultPageSettings.Landscape = PrintDoc.DefaultPageSettings.PaperSize.Width < screenCapture.Width;
        PrintDoc.OriginAtMargins = true;
        PrintDoc.PrintPage += (s, ppe) =>
        {
            Rectangle BitmapSize = new Rectangle(new Point(0, 0),
                                   new Size(screenCapture.Width, screenCapture.Height));
            Graphics _imagegraph = Graphics.FromImage(screenCapture);
            _imagegraph.CompositingMode = CompositingMode.SourceCopy;
            _imagegraph.CompositingQuality = CompositingQuality.HighQuality;
            _imagegraph.SmoothingMode = SmoothingMode.HighQuality;
            _imagegraph.PixelOffsetMode = PixelOffsetMode.HighQuality;
            _imagegraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            ImageAttributes ImageAttr = new ImageAttributes();
            ImageAttr.ClearThreshold(ColorAdjustType.Bitmap);
            ppe.Graphics.DrawImage(screenCapture, BitmapSize, 0F, 0F,
                                   BitmapSize.Width, BitmapSize.Height, GraphicsUnit.Pixel, ImageAttr);
        };
        PrintPreviewDialog pPreviewDiag = new PrintPreviewDialog();
        pPreviewDiag.Document = PrintDoc;
        pPreviewDiag.AutoScaleDimensions = new SizeF(Screen.PrimaryScreen.BitsPerPixel * 1.5F,
                                                     Screen.PrimaryScreen.BitsPerPixel * 1.5F);
        pPreviewDiag.AutoScaleMode = AutoScaleMode.Dpi;
        pPreviewDiag.StartPosition = FormStartPosition.CenterScreen;
        pPreviewDiag.ShowDialog();
    }
