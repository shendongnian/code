    int imageWidth, imageHeight;
    using (Stream imageStream = ResourceManager.CreateFile(finalResourceId, imageFileName))
    {
        using (Image img = Image.FromStream(new MemoryStream(imageFile.ResourceObject)))
        {
            imageWidth = img.Width;
            imageHeight = img.Height;
        }
        imageStream.Write(imageFile.ResourceObject, 0, imageFile.ResourceObject.Length);
    }
