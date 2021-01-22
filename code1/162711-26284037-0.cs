     public FileResult DownloadFile(string id)
    {
    try
    {
        byte[] imageBytes =  ANY IMAGE SOURCE (PNG)
        MemoryStream ms = new MemoryStream(imageBytes);
        var image = System.Drawing.Image.FromStream(ms);
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        var fileName = string.Format("{0}.png", "ANY GENERIC FILE NAME");
        return File(ms.ToArray(), "image/png", fileName);
    }
    catch (Exception)
    {
    }
    return null;
    }
