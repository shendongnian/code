    public Bitmap PrintControlFromScreen(Control SourceControl, float Dpi, bool ClientAreaOnly, bool ScaleToDpi, InterpolationMode Interpolation)
    {
        using (Graphics graphics = SourceControl.CreateGraphics())
        {
            SizeF ScaleFactor = new SizeF((Dpi / graphics.DpiX), (Dpi / graphics.DpiY));
            SizeF BitmapSize;
            if (ScaleToDpi)
            {
                BitmapSize = ClientAreaOnly ? new SizeF((SourceControl.ClientRectangle.Size.Width * ScaleFactor.Width),
                                                        (SourceControl.ClientRectangle.Size.Height * ScaleFactor.Height))
                                            : new SizeF((SourceControl.Bounds.Size.Width * ScaleFactor.Width),
                                                        (SourceControl.Bounds.Size.Height * ScaleFactor.Height));
            }
            else
            {
                BitmapSize = ClientAreaOnly ? SourceControl.ClientRectangle.Size : SourceControl.Bounds.Size;
            }
            using (Bitmap bitmap = new Bitmap((int)BitmapSize.Width, (int)BitmapSize.Height))
            {
                bitmap.SetResolution(ScaleFactor.Width * graphics.DpiX, ScaleFactor.Height * graphics.DpiY);
                using (Graphics ImageGraph = Graphics.FromImage(bitmap))
                {
                    ImageGraph.CompositingQuality = CompositingQuality.HighQuality;
                    ImageGraph.CompositingMode = CompositingMode.SourceCopy;
                    ImageGraph.SmoothingMode = SmoothingMode.HighQuality;
                    ImageGraph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    ImageGraph.InterpolationMode = Interpolation;
                    if (ClientAreaOnly)
                    {
                        ImageGraph.CopyFromScreen(SourceControl.PointToScreen(SourceControl.ClientRectangle.Location),
                                                new Point(0, 0), SourceControl.ClientRectangle.Size);
                    }
                    else
                    {
                        if (SourceControl.TopLevelControl == SourceControl)
                        {
                            ImageGraph.CopyFromScreen(SourceControl.Bounds.Location,
                                                    new Point(0, 0), SourceControl.Bounds.Size);
                        }
                        else
                        {
                            ImageGraph.CopyFromScreen(SourceControl.PointToScreen(SourceControl.ClientRectangle.Location),
                                                    new Point(0, 0), SourceControl.Size);
                        }
                    }
                    if (ScaleToDpi) ImageGraph.ScaleTransform(ScaleFactor.Width, ScaleFactor.Height);
                    ImageGraph.DrawImage(bitmap, new Point(0, 0));
                    return (Bitmap)bitmap.Clone();
                };
            };
        };
    }
