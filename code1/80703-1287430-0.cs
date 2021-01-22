        public const int IMAGE_DPI = 96;
        public Image GenerateImage(T control)
            where T : Control, new()
        {
            Size size = RetrieveDesiredSize(control);
            Rect rect = new Rect(0, 0, size.Width, size.Height);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)size.Width, (int)size.Height, IMAGE_DPI, IMAGE_DPI, PixelFormats.Pbgra32);
            control.Arrange(rect); //Let the control arrange itself inside your Rectangle
            rtb.Render(control); //Render the control on the RenderTargetBitmap
            //Now encode and convert to a gdi+ Image object
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(rtb));
            using (MemoryStream stream = new MemoryStream())
            {
                png.Save(stream);
                return Image.FromStream(stream);
            }
        }
        private Size RetrieveDesiredSize(T control)
        {
            if (Equals(control.Width, double.NaN) || Equals(control.Height, double.NaN))
            {
                //Make sure the control has measured first:
                control.Measure(new Size(double.MaxValue, double.MaxValue));
                return control.DesiredSize;
            }
            return new Size(control.Width, control.Height);
        }
