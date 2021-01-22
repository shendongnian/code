        private static Bitmap WatermarkImage(Bitmap bmpOriginal, String waterMarkLeft, String waterMarkRight)
        {
            using (Graphics gfxOriginal = Graphics.FromImage(bmpOriginal))
            {
                using (Font fntWatermark = new Font("Arial", 12, FontStyle.Regular))
                {                    
                    SizeF szWatermarkLeft = gfxOriginal.MeasureString(waterMarkLeft, fntWatermark, int.MaxValue);
                    SizeF szWatermarkRight = gfxOriginal.MeasureString(waterMarkRight, fntWatermark, int.MaxValue);
                    float heightWatermark = szWatermarkLeft.Height > szWatermarkRight.Height ? szWatermarkLeft.Height : szWatermarkRight.Height;
                    Bitmap bmpWatermarked = new Bitmap(bmpOriginal.Width, bmpOriginal.Height + (int)(heightWatermark * 2));
                    using (Graphics gfxWatermarked = Graphics.FromImage(bmpWatermarked))
                    {
                        gfxWatermarked.Clear(Color.White);
                        gfxWatermarked.DrawImageUnscaled(bmpOriginal, 0, 0);
                        gfxWatermarked.DrawString(waterMarkLeft, fntWatermark, Brushes.Black, 0, (bmpOriginal.Height + heightWatermark) - (szWatermarkLeft.Height / 2));
                        gfxWatermarked.DrawString(waterMarkRight, fntWatermark, Brushes.Black, (bmpOriginal.Width - szWatermarkRight.Width), (bmpOriginal.Height + heightWatermark) - (heightWatermark / 2));                        
                    }
                    return bmpWatermarked;                                        
                }
            }
        }
