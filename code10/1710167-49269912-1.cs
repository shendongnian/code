    string Barcode = "*8457QK3P9*";
    using (Bitmap bitmap = new Bitmap(300, 150))
    {
        bitmap.SetResolution(240, 240);
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            Font font = new Font("IDAutomationSHC39M", 10, FontStyle.Regular, GraphicsUnit.Point);
            graphics.Clear(Color.White);
            StringFormat stringformat = new StringFormat(StringFormatFlags.NoWrap);
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            graphics.TextContrast = 10;
            PointF TextPosition = new PointF(10F, 10F);
            SizeF TextSize = graphics.MeasureString(Barcode, font, TextPosition, stringformat);
            if (TextSize.Width > bitmap.Width)
            {
                float ScaleFactor = (bitmap.Width - (TextPosition.X / 2)) / TextSize.Width;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.ScaleTransform(ScaleFactor, ScaleFactor);
            }
            graphics.DrawString(Barcode, font, new SolidBrush(Color.Black), TextPosition, StringFormat.GenericTypographic);
            bitmap.Save(@"[SomePath]\[SomeName].png", ImageFormat.Png);
            this.pictureBox1.Image = (Bitmap)bitmap.Clone();
            font.Dispose();
        }
    }
