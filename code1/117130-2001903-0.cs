    public static Image CropImage(Image image, Rectangle area)
    {
        Image cropped = null;
    
        using (Bitmap i = new Bitmap(image))
        using (Bitmap c = i.Clone(area, i.PixelFormat))
            cropped = (Image)c;
    
        return cropped;
    }
