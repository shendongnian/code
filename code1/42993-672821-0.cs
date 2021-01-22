            var newBitmap = new Bitmap(NewWidth, NewHeight)
            using (Graphics g = Graphics.FromImage(YourBitmapHere))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(newBitmap, new Rectangle(0, 0, NewWidth, NewHeight));
            }
