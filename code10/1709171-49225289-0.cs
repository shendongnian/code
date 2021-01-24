    string[] TextLines = new string[] { "First Line of Text", 
                                        "Secon Line of Text a bit larger than the one before", 
                                        "Third Line of Text, this is mid-sized." };
    using (Bitmap bitmap = new Bitmap(280, 200))
    {
        using (Graphics graphics = Graphics.FromImage(bitmap))
        {
            Font font = new Font("Calibri", 22, FontStyle.Regular, GraphicsUnit.Pixel);
            graphics.Clear(Color.Goldenrod);
            graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
            graphics.TextContrast = 10;
            StringFormat stringformat = new StringFormat(StringFormatFlags.LineLimit | 
                                                         StringFormatFlags.MeasureTrailingSpaces);
            stringformat.Trimming = StringTrimming.Word;
            float LineSpacing = 10.0F;
            float LeftMargin = 30F;
            float TextVerticalPosition = 10F;
            for (int i = 0; i < 3; i++)
            {
                SizeF TextSize = graphics.MeasureString(TextLines[i], font, (bitmap.Width - (int)LeftMargin), stringformat);
                PointF TextPosition = new PointF(LeftMargin, TextVerticalPosition);
                graphics.DrawString(TextLines[i], 
                                    font, 
                                    new SolidBrush(Color.Black),
                                    new RectangleF(TextPosition, TextSize), 
                                    StringFormat.GenericTypographic);
                TextVerticalPosition += TextSize.Height + LineSpacing;
            }
            graphics.Save();
            font.Dispose();
            graphics.DrawImage(bitmap, new Point(0, 0));
        }
    }
