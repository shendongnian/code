    //Render a bitmap image
    await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
    {
        await bitmap.RenderAsync(canvas, 1380, 800);
        using (var inputImgStream = new InMemoryRandomAccessStream()) //this doesn't work
        {                        
            var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId,
                inputImgStream
                    ); // I suspect passing the MemoryStream is the issue. While 'StorageFile' is used there are no issues.
    
            IBuffer pixelBuffer = await bitmap.GetPixelsAsync();
            Debug.WriteLine($"Capacity = {pixelBuffer.Capacity}, Length={pixelBuffer.Length}");
    
            var pixelArray = pixelBuffer.ToArray();
            encoder.SetPixelData(
                BitmapPixelFormat.Bgra8,
                BitmapAlphaMode.Ignore,
                (uint) bitmap.PixelWidth,
                (uint) bitmap.PixelHeight,
                DisplayInformation.GetForCurrentView().LogicalDpi,
                DisplayInformation.GetForCurrentView().LogicalDpi,
                pixelArray
            );
    
            await encoder.FlushAsync(); // The application hangs here
        }
    });
