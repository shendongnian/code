    Image newImage = Image.FromFile(myFilePath);
    Size outputSize = new Size(200, 200);
    Bitmap backgroundBitmap = new Bitmap(outputSize.Width, outputSize.Height);
    using (Bitmap tempBitmap = new Bitmap(newImage))
    {
        using (Graphics g = Graphics.FromImage(backgroundBitmap))
        {
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Get the set of points that determine our rectangle for resizing.
            Point[] corners = {
                new Point(0, 0),
                new Point(backgroundBitmap.Width, 0),
                new Point(0, backgroundBitmap.Height)
            };
            g.DrawImage(tempBitmap, corners);
        }
    }
    this.BackgroundImage = backgroundBitmap;
