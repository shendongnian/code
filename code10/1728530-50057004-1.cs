    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
        }
    }
    
    void UpdateImage()
    {
        byte[] imgByte = File.ReadAllBytes(path);
        Texture2D texture = new Texture2D(2, 2);
        texture.LoadImage(imgByte);
    
        image.texture = texture;
    }
