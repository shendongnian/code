    private async void mediaPlayer_VideoFrameAvailable(MediaPlayer sender, object args)
    {
        CanvasDevice canvasDevice = CanvasDevice.GetSharedDevice();
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
        {
            SoftwareBitmap softwareBitmapImg;
            SoftwareBitmap frameServerDest = new SoftwareBitmap(BitmapPixelFormat.Rgba8, 100, 100, BitmapAlphaMode.Premultiplied);
    
            using (CanvasBitmap canvasBitmap = CanvasBitmap.CreateFromSoftwareBitmap(canvasDevice, frameServerDest))
            {
                sender.CopyFrameToVideoSurface(canvasBitmap);
    
                softwareBitmapImg = await SoftwareBitmap.CreateCopyFromSurfaceAsync(canvasBitmap);
    
            }
            await ExtractText(softwareBitmapImg);
        });
    }
