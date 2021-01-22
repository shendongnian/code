    private Image BuildBitmap(Image[,] parts) {
        // assumes all images are of equal size, assumes arrays are 0-based
        int xCount = parts.GetUpperBound(0) + 1;
        int yCount = parts.GetUpperBound(0) + 1;
        if (xCount <= 0 || yCount <= 0)
            return null; // no images to join
        int width = parts[0,0].Width;
        int height = parts[0,0].Height;
        Bitmap newPicture = new Bitmap(width * xCount, height * yCount);
        using (Graphics g = Graphics.FromImage(newPicture)) {
            for (int x = 0; x < xCount; x++)
                for (int y = 0; y < yCount; y++)
                    g.DrawImage(parts[x, y], x * width, y & height); 
        }
        return newPicture;
    }
