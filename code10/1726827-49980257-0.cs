    private void SetPixel(int x, int y)
    {
        WriteableBitmap wrb = image.Source as WriteableBitmap;
        if (wrb == null)
        {
            wrb = new WriteableBitmap((BitmapSource)image.Source);
            image.Source = wrb;
        }
        byte[] color = new byte[] { b, g, r, a };
        wrb.WritePixels(new Int32Rect(x, y, 1, 1), color, 4, 0);
    }
