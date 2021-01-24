    public void ProcessFrame(ProcessVideoFrameContext context, int X, int Y)
        {
        using (CanvasBitmap inputBitmap = CanvasBitmap.CreateFromDirect3D11Surface(canvasDevice, context.InputFrame.Direct3DSurface))
        using (CanvasRenderTarget renderTarget = CanvasRenderTarget.CreateFromDirect3D11Surface(canvasDevice, context.OutputFrame.Direct3DSurface))
        using (CanvasDrawingSession ds = renderTarget.CreateDrawingSession())
        {
            Color[] Pixels = inputBitmap.GetPixelColors();
            // Manipulate the array using X and Y with the Width parameter of the bitmap
            var gaussianBlurEffect = new GaussianBlurEffect
            {
                Source = inputBitmap,
                BlurAmount = (float)BlurAmount,
                Optimization = EffectOptimization.Speed
            };
            ds.DrawImage(gaussianBlurEffect);
        }
    }
