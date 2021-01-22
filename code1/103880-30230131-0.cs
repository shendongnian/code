    using (var graphics = Graphics.FromImage(destImage))
                {
                    using (var wrapMode = new ImageAttributes())
                    {
                        
    
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.CompositingMode = CompositingMode.SourceCopy;
                        graphics.CompositingQuality = CompositingQuality.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
    
                    }              
                }
    
                using (var graphics = Graphics.FromImage(destImage))
                {
                    var font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
                    var brush = new SolidBrush(Color.White);
                    graphics.DrawString("text to add", font, brush, 10F, 10F);
                    font.Dispose();
                    brush.Dispose();
                }
