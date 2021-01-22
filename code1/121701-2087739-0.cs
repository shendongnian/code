    private static Bitmap WatermarkImage(Bitmap bmpOriginal, String waterMark)
    {
        using (Graphics gfxOriginal = Graphics.FromImage(bmpOriginal))
        {
            using (Font fntWatermark = new Font("Arial", 12, FontStyle.Regular))
            {
                SizeF szWatermark = gfxOriginal.MeasureString(waterMark, fntWatermark, int.MaxValue);
    
                Bitmap bmpWatermarked = new Bitmap(bmpOriginal.Width, bmpOriginal.Height + (int)(szWatermark.Height * 2));
                
                using (Graphics gfxWatermarked = Graphics.FromImage(bmpWatermarked))
                {
                    gfxWatermarked.Clear(Color.White);
                    gfxWatermarked.DrawImageUnscaled(bmpOriginal, 0, 0);
                    gfxWatermarked.DrawString(waterMark, fntWatermark, Brushes.Black, (bmpOriginal.Width - szWatermark.Width), (bmpOriginal.Height + szWatermark.Height) - (szWatermark.Height / 2));
                }
    
                return bmpWatermarked;                                        
            }
        }
    }
