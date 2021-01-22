        public Bitmap CreateNonIndexedImage(Image src)
        {
            Bitmap newBmp = new Bitmap(src.Width, src.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            
            using (Graphics gfx = Graphics.FromImage(newBmp)) {
                gfx.DrawImage(src, 0, 0);
            }
            
            return newBmp;
        }
