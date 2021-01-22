            var openBitmap = new Bitmap("FileToOpenPathHere");
            var newBitmap = new Bitmap(NewWidth, NewHeight)
            using (Graphics g = Graphics.FromImage(openBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(newBitmap, new Rectangle(0, 0, NewWidth, NewHeight));
            }
            openBitmap.Dispose();
            newBitmap.Save("FileToSavePath", ImageFormat.Jpeg); //Full JPEG 100% Quality And 100% Compression
 
