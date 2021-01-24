    private Image ImageFromBytes(byte[] imageBytes)
    {
        using (var ms = new MemoryStream(imageBytes))
        {
            using (var image = Image.FromStream(ms))
            {
                return (Image)image.Clone();
            }
        }
    }
