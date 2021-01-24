     private async void Button_Click(object sender, RoutedEventArgs e)
            {
                RenderTargetBitmap rtb = new RenderTargetBitmap();
                await rtb.RenderAsync(GridToBeRendered);
    
                var pixelBuffer = await rtb.GetPixelsAsync();
                var pixels = pixelBuffer.ToArray();
                var displayInformation = DisplayInformation.GetForCurrentView();
                StorageFolder myfolder = ApplicationData.Current.LocalFolder;
                StorageFile file;
                file = await myfolder.CreateFileAsync("Render" + ".png", CreationCollisionOption.GenerateUniqueName);
                if (file != null)
                {
                    using (var stream = await file.OpenAsync(FileAccessMode.ReadWrite))
                    {
                        var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                        encoder.SetPixelData(BitmapPixelFormat.Bgra8,
                                             BitmapAlphaMode.Premultiplied,
                                             (uint)rtb.PixelWidth,
                                             (uint)rtb.PixelHeight,
                                             displayInformation.RawDpiX,
                                             displayInformation.RawDpiY,
                                             pixels);
                        await encoder.FlushAsync();
                    }
                }
                await Launcher.LaunchFileAsync(file);
            }
