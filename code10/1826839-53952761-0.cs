    /// <summary>
    /// Takes a screenshot of the specified section of the screen.
    /// </summary>
    public void Screenshot(string filename, ImageFormat imageFormat, int width, int height, int sourceX, int sourceY, int destX, int destY)
    {
        var bm = new Bitmap(width, height);
        var gr = Graphics.FromImage(bm);
        gr.CopyFromScreen(sourceX, sourceY, destX, destY, bm.Size);
        bm.Save(filename, imageFormat);
    }
