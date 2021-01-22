    private Bitmap ImageGenerator()
        {
            var transform = this.LayoutTransform;
            // Call UpdateLayout to make sure changes all changes 
            // while drawing objects on canvas are reflected
            var layer = AdornerLayer.GetAdornerLayer(this);
            layer?.UpdateLayout();
            // Get the size of canvas
            var size = new System.Windows.Size(this.ActualWidth, this.ActualHeight);
            // Measure and arrange the surface
            // VERY IMPORTANT
            this.Measure(size);
            this.Arrange(new Rect(RenderSize));
            RenderTargetBitmap renderBitmap =
                         new RenderTargetBitmap(
                           (int)this.ActualWidth,
                           (int)this.ActualHeight,
                           96d,
                           96d,
                           PixelFormats.Pbgra32);
            renderBitmap.Render(this);
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            // push the rendered bitmap to it
            encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
            var stream = new MemoryStream();
            encoder.Save(stream);
            this.LayoutTransform = transform;
            return new Bitmap(stream);
        }
