    public static byte[] CreatePngImage(this UIElement element)
    {
        WriteableBitmap screenshot = new WriteableBitmap(element, new TranslateTransform());
        var image =  screenshot.ToImage();
        ImageTools.IO.Png.PngEncoder png = new ImageTools.IO.Png.PngEncoder();
        using (var mem = new System.IO.MemoryStream())
        {
            png.Encode(image, mem);
            var bytes = mem.GetBuffer();
            return bytes;
        }
    }
