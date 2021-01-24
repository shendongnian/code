    public RenderTargetBitmap GetImage()
    {
        Size size = sp_ports.DesiredSize;
        if (size.IsEmpty)
            return null;
        RenderTargetBitmap result = new RenderTargetBitmap((int)size.Width, (int)size.Height, 96, 96, PixelFormats.Pbgra32);
        result.Render(sp_ports);
        return result;
    }
