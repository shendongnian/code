    void WritePng(string path, UIElement element)
    {
      // Create the bitmep specifying the size, pixel format and DPI
      var bitmap = new RenderTargetBitmap((int)element.Width, (int)element.Height,
                                          96, 96, PixelFormats.Pbgra32);
      bitmap.Render(element); // At this point the bitmap is usable within WPF
      // Write to a file:  WPF can write multiple frames but we need only one
      var encoder = new PngBitmapEncoder();
      encoder.Frames.Add(BitmapFrame.Create(bitmap));
      using(Stream stream = File.Create(path))
        encoder.Save(stream);  // Could be any stream, not just a file
    }
