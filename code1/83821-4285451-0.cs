    public static Icon Convert(BitmapImage bitmapImage)
    {
        var ms = new MemoryStream();
        var encoder = new PngBitmapEncoder(); // With this we also respect transparency.
        encoder.Frames.Add(BitmapFrame.Create(bitmapImage));
        encoder.Save(ms);
        var bmp = new Bitmap(ms);
        return Icon.FromHandle(bmp.GetHicon());
    }
