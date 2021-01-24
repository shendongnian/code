    private byte[] TransformAvatarIfNeeded(byte[] imageInBytes)
    {
        using (var image = Image.Load(imageInBytes, out var imageFormat ))
        {
            image.Mutate(x => x.AutoOrient());
            return ImageToByteArray(image, imageFormat);
        }
    }
