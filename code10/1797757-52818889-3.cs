    private async void Tm_Tick(object sender, object e)
    {
        RenderTargetBitmap rendertargetBitmap = new RenderTargetBitmap();
        await rendertargetBitmap.RenderAsync(myGrid);
        var bfr = await rendertargetBitmap.GetPixelsAsync();
        
        CanvasRenderTarget rendertarget = null
        using (CanvasBitmap canvas = CanvasBitmap.CreateFromBytes(CanvasDevice.GetSharedDevice(), bfr, rendertargetBitmap.PixelWidth, rendertargetBitmap.PixelHeight, Windows.Graphics.DirectX.DirectXPixelFormat.B8G8R8A8UIntNormalized))
        {
            rendertarget = new CanvasRenderTarget(CanvasDevice.GetSharedDevice(), canvas.SizeInPixels.Width, canvas.SizeInPixels.Height, 96);
            using (CanvasDrawingSession ds = rendertarget.CreateDrawingSession())
            {
                ds.Clear(Colors.Black);
                ds.DrawImage(canvas);
            }
        }
        MediaClip m = MediaClip.CreateFromSurface(rendertarget, TimeSpan.FromMilliseconds(80));
        mc.Clips.Add(m);
    }
