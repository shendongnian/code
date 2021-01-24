                // get byte-array from file
                using (var xamlStream = new MemoryStream((byte[])value))
                using (var stream = new MemoryStream())
                {
                    var dataContext = new DataPackageController();
                    dataContext.SetData(context);
                    var thread = new Thread(() =>
                    {
                        // load xaml control from stream
                        var control = (System.Windows.Controls.Canvas)System.Windows.Markup.XamlReader.Load(xamlStream);
                        if (control == null)
                            return;
                        control.DataContext = new { Person = new { FIRSTNAME = "Test" } };
                        control.Measure(new System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
                        // get size of control which would be needed by Window
                        var controlSize = control.DesiredSize;
                        var rect = new System.Windows.Rect(0, 0, controlSize.Width, controlSize.Height);
                        // render XAML to bitmap
                        var targetBitmap = new RenderTargetBitmap((int)controlSize.Width, (int)controlSize.Height, 120, 96, PixelFormats.Pbgra32);
                        control.Arrange(rect);
                        control.InvalidateVisual();
                        control.UpdateLayout();
                        targetBitmap.Render(control);
                        // convert to png and save to sream
                        var png = new PngBitmapEncoder();
                        png.Frames.Add(BitmapFrame.Create(targetBitmap));
                        png.Save(stream);
                    });
                    thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                    thread.Start();
                    thread.Join();
                }
