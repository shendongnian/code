    public override void getThumbnail(string filePath)
    {
        using (Image image = Image.FromFile(filePath))
        {
            Thumbnail = image.GetThumbnailImage(40, 40, null, new IntPtr());
        }
    }
