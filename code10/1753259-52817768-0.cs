    CanvasRenderTarget rendertarget;
    using (CanvasBitmap canvas = CanvasBitmap.CreateFromBytes(CanvasDevice.GetSharedDevice(), pixels, renderTargetBitmap.PixelWidth, renderTargetBitmap.PixelHeight, format))
    {
         rendertarget = new CanvasRenderTarget(CanvasDevice.GetSharedDevice(), canvas.SizeInPixels.Width, canvas.SizeInPixels.Height, 96);
         using (CanvasDrawingSession ds = rendertarget.CreateDrawingSession())
         {
             ds.Clear(Colors.Black);
             ds.DrawImage(canvas);
         }
    }
    MediaClip d = MediaClip.CreateFromSurface(renderTarget, TimeSpan.FromMilliseconds(80));
    mc.Clips.Add(m);
