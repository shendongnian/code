        public Image ResizeImage(Image openImage, int NewWidth, int NewHeight) {
            var openBitmap = new Bitmap(openImage);
            var newBitmap = new Bitmap(NewWidth, NewHeight);
            using (Graphics g = Graphics.FromImage(openBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(newBitmap, new Rectangle(0, 0, NewWidth, NewHeight));
            }
            openBitmap.Dispose(); //Clear The Old Large Bitmap From Memory
            
            return (Image)newBitmap;
        }
 
