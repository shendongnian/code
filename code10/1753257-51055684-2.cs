    private async void CreateVideoByConvertRenderBitmapToFile()
    {
        var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Test", 
            CreationCollisionOption.ReplaceExisting);
        var composition = new MediaComposition();
        for (int i = 0; i < 5; i++)
        {
            RenderTargetBitmap render = new RenderTargetBitmap();
            await render.RenderAsync(RenderGrid);
            MyImage.Source = render;
            var pixel = await render.GetPixelsAsync();
            var file = await folder.CreateFileAsync("test.png", CreationCollisionOption.GenerateUniqueName);
            using (IRandomAccessStream stream = await file.OpenAsync(FileAccessMode.ReadWrite))
            {
                var logicalDpi = DisplayInformation.GetForCurrentView().LogicalDpi;
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId, stream);
                encoder.SetPixelData(
                    BitmapPixelFormat.Bgra8,
                    BitmapAlphaMode.Ignore,
                    (uint)render.PixelWidth,
                    (uint)render.PixelHeight,
                    logicalDpi,
                    logicalDpi,
                    pixel.ToArray());
                await encoder.FlushAsync();
                stream.Dispose();
                MediaClip clip = await MediaClip.CreateFromImageFileAsync(file, TimeSpan.FromSeconds(3));
                composition.Clips.Add(clip);
                MyText.Text = "First frame >>>" + i;
            }
        }
        var video = await ApplicationData.Current.LocalFolder.CreateFileAsync("test.mp4",
            CreationCollisionOption.ReplaceExisting);
        var action = await composition.RenderToFileAsync(video, MediaTrimmingPreference.Precise);
        await folder.DeleteAsync();
    }
