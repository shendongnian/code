    public System.Drawing.Image ConvertControlsImageToDrawingImage(System.Windows.Controls.Image imageControl)
    {
        RenderTargetBitmap rtb2 = new RenderTargetBitmap((int)imageControl.Width, (int)imageControl.Height, 90, 90, PixelFormats.Default);
        rtb2.Render(imageControl);
    
        PngBitmapEncoder png = new PngBitmapEncoder();
        png.Frames.Add(BitmapFrame.Create(rtb2));
    
        Stream ms = new MemoryStream();
        png.Save(ms);
    
        ms.Position = 0;
    
        System.Drawing.Image retImg = System.Drawing.Image.FromStream(ms);
        return retImg;
    }
