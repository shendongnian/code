            public void GeneratePng(Grid mapGrid, string pngURI)
            {
                double dpi = App.mvm.SelectedDPI;
                double scale = dpi / 96;
                Rect bounds = VisualTreeHelper.GetDescendantBounds(mapGrid);
                RenderTargetBitmap rt = new RenderTargetBitmap((int)(bounds.Width * scale),
                                                               (int)(bounds.Height * scale),
                                                                dpi,
                                                                dpi,
                                                                PixelFormats.Pbgra32);
                DrawingVisual dv = new DrawingVisual();
                using (DrawingContext ctx = dv.RenderOpen())
                {
                    VisualBrush vb = new VisualBrush(mapGrid);
                    ctx.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
                }
                rt.Render(dv);
                PngBitmapEncoder png = new PngBitmapEncoder();
                png.Frames.Add(BitmapFrame.Create(rt));
                using (Stream streamPng = File.Create(pngURI))
                {
                    png.Save(streamPng);
                }
            }
