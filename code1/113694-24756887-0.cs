    public string CreateThumbnail(int maxWidth, int maxHeight, string path)
    {
        var image = System.Drawing.Image.FromFile(path);
        var ratioX = (double)maxWidth / image.Width;
        var ratioY = (double)maxHeight / image.Height;
        var ratio = Math.Min(ratioX, ratioY);
        var newWidth = (int)(image.Width * ratio);
        var newHeight = (int)(image.Height * ratio);
        var newImage = new Bitmap(newWidth, newHeight);
        Graphics thumbGraph = Graphics.FromImage(newImage);
        thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
        thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
        //thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
        thumbGraph.DrawImage(image, 0, 0, newWidth, newHeight);
        image.Dispose();
        string fileRelativePath = "newsizeimages/" + maxWidth + Path.GetFileName(path);
        newImage.Save(Server.MapPath(fileRelativePath), newImage.RawFormat);
        return fileRelativePath;
    }
