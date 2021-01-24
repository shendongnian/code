        public static async Task<BitmapSource> GetGridImageAsync(FrameworkElement fe)
        {
            Matrix m = PresentationSource.FromVisual(fe)
                .CompositionTarget.TransformToDevice;
            double dpiFactor = 1 / m.M11;
            return await Task.Run(() =>
            {
                Pen GreyPen = new Pen(Brushes.Gray, 1 * dpiFactor);
                Pen GreyThickPen = new Pen(Brushes.Gray, 2 * dpiFactor);
                GreyPen.Freeze();
                int ix = 0;
                int iy = 0;
                int Width = 1155;
                int Height = 805;
                BitmapSource image = Visuals.CreateBitmap(
                   Width, Height, 96,
                    drawingContext =>
                    {
                        int count = 0;
                        while (ix <= Width)
                        {
                            if (count % 5 == 0)
                            {
                                drawingContext.DrawLine(
                                   GreyThickPen, new Point(ix, 0), new Point(ix, Map.Height - 1));
                            }
                            else
                            {
                                drawingContext.DrawLine(
                                    GreyPen, new Point(ix, 0), new Point(ix, Map.Height - 1));
                            }
                            ix += 35;
                            count++;
                        }
                        count = 0;
                        while (iy <= Width)
                        {
                            if (count % 5 == 0)
                            {
                                drawingContext.DrawLine(
                                GreyThickPen, new Point(0, iy), new Point(Map.Width -1, iy));
                            }
                            else
                            {
                                drawingContext.DrawLine(
                                GreyPen, new Point(0, iy), new Point(Map.Width - 1, iy));
                            }
                            iy += 35;
                            count++;
                        }
                    });
                return image;
            });
        }
    }
