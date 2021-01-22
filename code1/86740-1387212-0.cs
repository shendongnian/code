    protected Stream ResizeImage(string source, int width, int height) {
                using (System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)System.Drawing.Bitmap.FromFile(source))
                using (System.Drawing.Bitmap newBmp = new System.Drawing.Bitmap(width, height)) 
                using (System.Drawing.Graphics graphic = System.Drawing.Graphics.FromImage(newBmp))
                {
                            
                    graphic.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    graphic.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    graphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
    
                    graphic.DrawImage(bmp, 0, 0, width, height);
    
                    MemoryStream ms = new MemoryStream();
                    newBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms;
                  
                }             
            }
