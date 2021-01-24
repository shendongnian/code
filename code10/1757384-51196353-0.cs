        public static BitmapSource Create(UIElement control, Size size = default(Size))
        {
            if (control == null)
                return null;
            if (size == Size.Empty || (size.Height == 0 && size.Width == 0))
                size = new Size(double.PositiveInfinity, double.PositiveInfinity);
            control.Measure(size);
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)control.DesiredSize.Width, (int)control.DesiredSize.Height, 96, 96, PixelFormats.Pbgra32);
            Rect rect = new Rect(0, 0, control.DesiredSize.Width, control.DesiredSize.Height);
            control.Arrange(rect);
            control.UpdateLayout();
            bmp.Render(control);
            bmp.Freeze();
            return bmp;
        }
