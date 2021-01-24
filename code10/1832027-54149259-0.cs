        private async Task<WriteableBitmap> ChangeBrightness(WriteableBitmap source, float increment)
        {
            var canvasBitmap = CanvasBitmap.CreateFromBytes(CanvasDevice.GetSharedDevice(), source.PixelBuffer,
                source.PixelWidth, source.PixelHeight, DirectXPixelFormat.B8G8R8A8UIntNormalized);
            var brightnessFx = new BrightnessEffect
            {
                Source = canvasBitmap,
                BlackPoint = new Vector2(0, increment)
            };
            var crt = new CanvasRenderTarget(CanvasDevice.GetSharedDevice(), source.PixelWidth, source.PixelHeight, 96);
            using (var ds = crt.CreateDrawingSession())
            {
                ds.DrawImage(brightnessFx);
            }
            crt.GetPixelBytes(source.PixelBuffer);
            return source;
        }
