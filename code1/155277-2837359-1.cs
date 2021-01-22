    public Color GetPixelColor(Visual visual, int x, int y)
    {
      return GetAverageColor(visual, new Rect(x,y,1,1));
    }
    public Color GetAverageColor(Visual visual, Rect area)
    {
      var bitmap = new RenderTargetBitmap(1,1,96,96,PixelFormats.Pbgra32);
      bitmap.Render(
       new Rectangle
        {
          Width = 1, Height = 1,
          Fill = new VisualBrush { Visual = visual, Viewbox = area }
        });
      var bytes = new byte[4];
      bitmap.CopyPixels(bytes, 1, 0);
      return Color.FromArgb(bytes[0], bytes[1], bytes[2], bytes[3]);
    }
