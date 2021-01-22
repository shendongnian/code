    private List<Image> GetAllPages(string file)
    {
        List<Image> images = new List<Image>();
        Bitmap bitmap = (Bitmap)Image.FromFile(file);
        int count = bitmap.GetFrameCount(FrameDimension.Page);
        for (int idx = 0; idx < count; idx++)
        {
            // save each frame to a bytestream
            bitmap.SelectActiveFrame(FrameDimension.Page, idx);
            MemoryStream byteStream = new MemoryStream();
            bitmap.Save(byteStream, ImageFormat.Tiff);
    
            // and then create a new Image from it
            images.Add(Image.FromStream(byteStream));
        }
        return images;
    }
