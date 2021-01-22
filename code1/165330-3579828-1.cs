    public ImageSource ToImageSource(FrameworkElement obj)
        {
            // Save current canvas transform
            Transform transform = obj.LayoutTransform;
            obj.LayoutTransform = null;
            // Get the size of canvas
            Size size = new Size(obj.Width, obj.Height);
            // force control to Update
            obj.Measure(size);
            obj.Arrange(new Rect(size));
            RenderTargetBitmap bmp = new RenderTargetBitmap(
                (int)obj.Width, (int)obj.Height, 96, 96, PixelFormats.Pbgra32);
            bmp.Render(obj);
            // return values as they were before
            obj.LayoutTransform = transform;
            return bmp;
        }
